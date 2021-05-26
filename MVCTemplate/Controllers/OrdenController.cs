using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTemplate.Models;
using Newtonsoft.Json.Linq;

namespace MVCTemplate.Controllers
{
    public class OrdenController : Controller
    {

        CafeAguilarDB db = new CafeAguilarDB();

        // GET: Orden
        public ActionResult Index()
        {
            var list = from d in db.Ordens.AsEnumerable()
                       select d;
            return View(list);
        }

        public ActionResult NuevaOrden()
        {
            return View();
        }

        public ActionResult Details(int Id)
        {
            var list = from d in db.DetallesOrdenPostres.AsEnumerable()
                       where d.IDorden == Id
                       select d;
            return View(list);
        }

        public ActionResult CrearOrden()
        {
            try
            {
                var data = JObject.Parse(Request.Form["data"]);

                var lastRec = (from d in db.Ordens.AsEnumerable()
                               orderby d.IDorden descending
                               select d.IDorden).FirstOrDefault();

                var id = (lastRec == 0) ? 1 : (lastRec + 1);

                var orden = new Orden()
                {
                    IDorden = id,
                    total = data.Value<decimal>("total"),
                    Fecha = DateTime.Now
                };

                db.Ordens.Add(orden);
                db.SaveChanges();


                var productos = from d in data.Value<JArray>("productos")
                                select d;

                var actuales = new List<DetallesOrdenPostre>();

                foreach (var product in productos)
                {
                    var lr = (from d in db.DetallesOrdenPostres.AsEnumerable()
                              orderby d.ID descending
                              select d.ID).FirstOrDefault();
                    id = lr == 0 ? 1 : (lr + 1);

                    var entry = new DetallesOrdenPostre()
                    {
                        IDorden = orden.IDorden,
                        ID = id,
                        Cantidad = (from d in productos
                                    where d["Id"] == product["Id"]
                                    select d).Count(),
                        IDpostres = product.Value<int>("Id")
                    };

                    db.DetallesOrdenPostres.Add(entry);
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