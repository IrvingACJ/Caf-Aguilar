using MVCTemplate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCTemplate.Controllers
{
    public class PostresController : Controller
    {
        ModelCaféAguilarDB db = new ModelCaféAguilarDB();
        // GET: Postres
        public ActionResult Index()
        {
            var list = db.Postres.ToList();
            return View(list);
        }

        // GET: Postres/Details/5
        public ActionResult Details(int id)
        {
            var postre = db.Postres.Where(
                u => u.IDpostre == id).FirstOrDefault();
            return View(postre);
        }

        // GET: Postres/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Postres/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include =
            "IDpostre,Nombre,Precio")]Postres postre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lastRecord = db.Postres.OrderByDescending
                      (u => u.IDpostre).FirstOrDefault();
                    postre.IDpostre= ((lastRecord == null) ||
                        (lastRecord.IDpostre == 0))
                        ? 1 : lastRecord.IDpostre + 1;
                    db.Postres.Add(postre);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                return RedirectToAction("Index", new { message = "Error: " + exception });
            }
            return View();
        }

        // GET: Postres/Edit/5
        public ActionResult Edit(int id, string message = "")
        {
            var postre = db.Postres.Where(
                u => u.IDpostre == id).FirstOrDefault();
            ViewBag.errorMessage = message;
            return View(postre);
        }

        // POST: Postres/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include =
            "IDpostre,Nombre,Precio")]Postres postre)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(postre).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                return RedirectToAction("Index", new { message = "Error: " + exception });
            }
        }

        // GET: Postres/Delete/5
        public ActionResult Delete(int id)
        {
            var postre = db.Postres.Where(
                u => u.IDpostre == id).FirstOrDefault();
            return View(postre);
        }

        // POST: Postres/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete([Bind(Include =
            "IDpostre,Nombre,Precio")]Postres postre)
        {
            try
            {
                var delpostre = db.Postres.Where(
                    u => u.IDpostre == postre.IDpostre).FirstOrDefault();
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(delpostre).State = EntityState.Deleted;
                    db.Postres.Remove(delpostre);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", new { message = "Postre Eliminado" });
                }
                return RedirectToAction("Index", new { message = "Error" });
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                return RedirectToAction("Index", new { message = "Error: " + exception });
            }
        }
    
        public ActionResult getDetallesPostre(int Id)
        {
            var postre = (from d in db.Postres.AsEnumerable()
                         where d.IDpostre == Id
                         select new
                         {
                             d.Nombre,
                             d.Precio,
                             Id = d.IDpostre
                         }).FirstOrDefault();

            return postre == null ? Json(new { status = "BAD" }, JsonRequestBehavior.AllowGet)
                : Json(new { status = "OK", info = postre }, JsonRequestBehavior.AllowGet);

            //return Json(postre.FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
    }
}
