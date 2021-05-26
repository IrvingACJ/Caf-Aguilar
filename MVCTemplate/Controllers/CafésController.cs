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
        CafeAguilarDB db = new CafeAguilarDB();
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

        public ActionResult Create2(string nombre, int id_tamaño)
        {
            var lastRecord = db.Cafés.OrderByDescending(u => u.IDcafé).FirstOrDefault();
            var New_Café = new Cafés();
            try
            {
                if (lastRecord == null)
                { New_Café.IDcafé = 0; }
                else
                { New_Café.IDcafé = lastRecord.IDcafé + 1; }
                New_Café.Nombre = nombre;
                New_Café.IDtamaño = id_tamaño;
                db.Cafés.Add(New_Café);
                db.SaveChanges();
                return Content(Url.Action("Index", new { message = "Café Agregado" }));
                
            }
            catch (Exception ex)
            {
                return View("Error: "+ex);
            }
        }

        public ActionResult GetList()
        {
            var tam = from entry in db.Tamaños.AsEnumerable()
            select new {
                entry.IDtamaño,
                entry.Tamaño};
            tam = tam.ToList();
            var json = JsonConvert.SerializeObject(tam,Formatting.None);
            return Json(json);
        }

        // POST: Cafés/Create
        //[HttpPost]
        //public async Task<ActionResult> Create([Bind(Include =
        //    "IDcafé,Nombre,Regular, Grande,Rocas, Frappe, FechaModificacion")] Cafés café)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var lastRecord = db.Cafés.OrderByDescending
        //              (u => u).FirstOrDefault();
        //            if (lastRecord != null)
        //            {
        //                café.IDcafé = 0;
        //            }
        //            else
        //            {
        //                café.IDcafé += 1;
        //            }
        //            db.Cafés.Add(café);
        //            await db.SaveChangesAsync();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var exception = ex.ToString();
        //        return RedirectToAction("Index", new { message = "Error: " + exception });
        //    }
        //    return View();
        //}

        // GET: Cafés/Edit/5
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
