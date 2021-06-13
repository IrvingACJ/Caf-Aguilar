using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTemplate.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MVCTemplate.Controllers
{
    public class OrdenController : Controller
    {

        ModelCaféAguilarDB db = new ModelCaféAguilarDB();

        // GET: Orden
        public ActionResult Index()
        {
            var list = from d in db.Orden.AsEnumerable()
                       select d;
            return View(list);
        }

        public ActionResult GetList()
        {
            var list_P = from Postres in db.Postres.AsEnumerable()
                       select new { 
                           ID = Postres.IDpostre,
                           Nombre = Postres.Nombre,
                           Precio = Postres.Precio,
                           Tipo = "Postre"
                       };
            var list_C = from Cafés in db.Cafés.AsEnumerable()
                         select new
                         {
                             ID = Cafés.IDcafé,
                             Nombre = Cafés.Nombre + "-" + Cafés.Tipos.Tipo + "-" + Cafés.Tamaños.Tamaño,
                             Precio = Cafés.Precio,
                             Tipo = "Café"
                         };
            var list = list_P.Union(list_C); 
            var json = JsonConvert.SerializeObject(list.ToList(), Formatting.None);
            return Json(json);
        }
        public ActionResult NuevaOrden()
        {
            return View();
        }

        public ActionResult Details(int Id)
        {
            var list = from d in db.OrdenCompleta.AsEnumerable()
                       where d.IDorden == Id
                       select d;
            return View(list);
        }

        public ActionResult CrearOrden()
        {
            try
            {
                var data = JObject.Parse(Request.Form["data"]);

                var lastRec = (from d in db.Orden.AsEnumerable()
                               orderby d.IDorden descending
                               select d.IDorden).FirstOrDefault();

                    var id = (lastRec == 0) ? 1 : (lastRec + 1);

                var orden = new Orden()
                {
                    IDorden = id,
                    total = data.Value<decimal>("total"),
                    Fecha = DateTime.Now
                };

                db.Orden.Add(orden);
                db.SaveChanges();


                var productos = from d in data.Value<JArray>("productos")
                                select d;

                var actuales = new List<DetallesOrdenPostres>();

                foreach (var product in productos)
                {
                    string[] id_tipo =product["Id"].ToString().Split('-');
                    var lrP = (from d in db.DetallesOrdenPostres.AsEnumerable()
                              orderby d.ID descending
                              select d.ID).FirstOrDefault();
                    var idOrdenPostre = lrP == 0 ? 1 : (lrP + 1);
                    var lrC = (from d in db.DetallesOrdenCafés.AsEnumerable()
                              orderby d.ID descending
                              select d.ID).FirstOrDefault();
                    var idOrdenCafé = lrC == 0 ? 1 : (lrC + 1);
                    if (id_tipo[1] == "Postre")
                    {
                        var entryP = new DetallesOrdenPostres()
                        {
                            IDorden = orden.IDorden,
                            ID = idOrdenPostre,
                            Cantidad = (from d in productos
                                        where d["Id"] == product["Id"]
                                        select d).Count(),
                            IDpostres = Convert.ToInt32(id_tipo[0])
                        };
                        db.DetallesOrdenPostres.Add(entryP);
                    }
                    else if (id_tipo[1] == "Café")
                    {
                        var entryC = new DetallesOrdenCafés()
                        {
                            IDorden = orden.IDorden,
                            ID = idOrdenCafé,
                            Cantidad = (from d in productos
                                        where d["Id"] == product["Id"]
                                        select d).Count(),
                            IDcafé = Convert.ToInt32(id_tipo[0])
                        };
                        db.DetallesOrdenCafés.Add(entryC);
                    }
                    db.SaveChanges();
                }
                return Content("OK");
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
            

        }
    }
}