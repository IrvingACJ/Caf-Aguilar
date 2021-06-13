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
    public class TamañosController : Controller
    {
        ModelCaféAguilarDB db = new ModelCaféAguilarDB();
        // GET: Tamaños
        public ActionResult Index()
        {
            var Tamaños = db.Tamaños.ToList();
            return View(Tamaños);
        }

        // GET: Tamaños/Details/5
        public ActionResult Details(int id)
        {
            var Tamaños = db.Tamaños.ToList();
            return View();
        }

        // GET: Tamaños/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamaños/Create

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include =
            "IDtamaño,Tamaño")]Tamaños Tamaños)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lastRecord = db.Tamaños.OrderByDescending
                      (u => u.IDtamaño).FirstOrDefault();
                    Tamaños.IDtamaño= ((lastRecord == null) ||
                        (lastRecord.IDtamaño == 0))
                        ? 1 : lastRecord.IDtamaño + 1;
                    db.Tamaños.Add(Tamaños);
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


        // GET: Tamaños/Edit/5
        public ActionResult Edit(int id)
        {
            var Tamaños = db.Tamaños.Where(
                u => u.IDtamaño == id).FirstOrDefault();
            return View(Tamaños);
        }


        // POST: Tamaños/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include =
            "IDtamaño,Tamaño")]Tamaños tamaños)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(tamaños).State = EntityState.Modified;
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

        // GET: Tamaños/Delete/5
        public ActionResult Delete(int id)
        {
            var Tamaños = db.Tamaños.Where(
                u => u.IDtamaño == id).FirstOrDefault();
            return View(Tamaños);
        }
        [HttpPost]
        public async Task<ActionResult> Delete([Bind(Include =
            "IDtamaño")]Tamaños Tamaños)
        {
            try
            {
                var delTamaños = db.Tamaños.Where(
                    u => u.IDtamaño == Tamaños.IDtamaño).FirstOrDefault();
                // TODO: Add update logic here

                db.Entry(delTamaños).State = EntityState.Deleted;
                db.Tamaños.Remove(delTamaños);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { message = "Tamaño Eliminado" });
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                return RedirectToAction("Index", new { message = "Error: " + exception });
            }
        }
    }
}
