using MVCTemplate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Newtonsoft.Json;
namespace MVCTemplate.Controllers
{
    public class CafésController : Controller
    {
        // GET: Cafés
        ModelCaféAguilarDB db = new ModelCaféAguilarDB();
        public ActionResult Index()
        {
            var cafés = db.Cafés.ToList();
            return View(cafés);
        }

        // GET: Cafés/Details/5
        public ActionResult Details(int id)
        {
            var cafés = db.Cafés.Where(
                u => u.IDcafé == id).FirstOrDefault();
            return View(cafés);
        }

        // GET: Cafés/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create2(string nombre, int precio, int id_tamaño, int id_tipo)
        {
            var lastRecord = db.Cafés.OrderByDescending(u => u.IDcafé).FirstOrDefault();
            var New_Café = new Cafés();
            try
            {
                New_Café.IDcafé = ((lastRecord == null) ||
                    (lastRecord.IDcafé == 0))
                    ? 1 : lastRecord.IDcafé + 1;
                New_Café.Nombre = nombre;
                New_Café.Precio = precio;
                New_Café.IDtamaño = id_tamaño;
                New_Café.IDtipo = id_tipo;
                db.Cafés.Add(New_Café);
                db.SaveChanges();
                return Content(Url.Action("Index", new { message = "Café Agregado" }));
                
            }
            catch (Exception ex)
            {
                return View("Error: "+ex);
            }
        }

        public ActionResult GetList(string Option)
        {
            switch (Option)
            {
                case "Tamaños":
                    var tam = from entry in db.Tamaños.AsEnumerable()
                              select new
                              {
                                  entry.IDtamaño,
                                  entry.Tamaño
                              };
                    var json1 = JsonConvert.SerializeObject(tam.ToList(), Formatting.None);
                    return Json(json1);
                    break;
                case "Tipos":
                    var tipos = from entry in db.Tipos.AsEnumerable()
                              select new
                              {
                                  entry.IDtipo,
                                  entry.Tipo
                              };
                    var json2 = JsonConvert.SerializeObject(tipos.ToList(), Formatting.None);
                    return Json(json2);
                    break;
            }
            return Content("fail");
        }
        public ActionResult getDetallesCafé(int Id)
        {
            var postre = (from d in db.Cafés.AsEnumerable()
                          where d.IDcafé == Id
                          select new
                          {
                              d.Nombre,
                              d.Precio,
                              Id = d.IDcafé
                          }).FirstOrDefault();

            return postre == null ? Json(new { status = "BAD" }, JsonRequestBehavior.AllowGet)
                : Json(new { status = "OK", info = postre }, JsonRequestBehavior.AllowGet);

            //return Json(postre.FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id, string message = "")
        {
            var user = db.Cafés.Where(
                u => u.IDcafé == id).FirstOrDefault();
            ViewBag.errorMessage = message;
            return View(user);
        }

        public ActionResult Edit2(int IDcafé, string nombre, int id_tamaño)
        {
            var lastRecord = db.Cafés.Where
              (u => u.IDcafé == IDcafé).FirstOrDefault();
            try
            {
                db.Entry(lastRecord).State = EntityState.Deleted;
                db.Cafés.Remove(lastRecord);
                db.SaveChanges();
                lastRecord.Nombre = nombre;
                lastRecord.IDtamaño = id_tamaño;
                db.Cafés.Add(lastRecord);
                db.SaveChanges();
                return Content(Url.Action("Index", new { message = "Café Eliminado" }));
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                return RedirectToAction("Index", new { message = "Error: " + exception });
            }
        }

        // GET: Cafés/Delete/5
        public ActionResult Delete(int id)
        {
            var café = db.Cafés.Where(
                u => u.IDcafé == id).FirstOrDefault();
            return View(café);
        }
        [HttpPost]
        public async Task<ActionResult> Delete([Bind(Include =
            "IDcafé")]Cafés café)
        {
            try
            {
                var delcafé = db.Cafés.Where(
                    u => u.IDcafé == café.IDcafé).FirstOrDefault();
                // TODO: Add update logic here

                db.Entry(delcafé).State = EntityState.Deleted;
                db.Cafés.Remove(delcafé);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { message = "Café Eliminado" });
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                return RedirectToAction("Index", new { message = "Error: " + exception });
            }
        }
        public ActionResult Delete2(int IDcafé)
        {
            var lastRecord = db.Cafés.Where
              (u => u.IDcafé == IDcafé).FirstOrDefault();
            try
            {
                db.Entry(lastRecord).State = EntityState.Deleted;
                db.Cafés.Remove(lastRecord);
                db.SaveChangesAsync();
                return Content(Url.Action("Index", new { message = "Café Eliminado" }));
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                return RedirectToAction("Index", new { message = "Error: " + exception });
            }
        }
    }
}
