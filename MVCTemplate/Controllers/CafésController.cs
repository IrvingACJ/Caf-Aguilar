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
    public class CafésController : Controller
    {
        // GET: Cafés
        ModelBD db = new ModelBD();
        public ActionResult Index()
        {
            var cafés = db.Cafés.ToList();
            return View(cafés);
        }

        // GET: Cafés/Details/5
        public ActionResult Details(string id)
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

        // POST: Cafés/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include =
            "IDcafé,Nombre,Regular, Grande,Rocas, Frappe, FechaModificacion")] Cafés café)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lastRecord = db.Cafés.OrderByDescending
                      (u => u.FechaModificacion).FirstOrDefault();
                    if (lastRecord != null)
                    {
                        string ID = lastRecord.IDcafé.Replace("C", "");
                        int newint = Convert.ToInt32(ID) + 1;
                        café.IDcafé = newint + "C";
                    }
                    else
                    {
                        café.IDcafé = "0C";
                    }
                    café.FechaModificacion = DateTime.Now;
                    db.Cafés.Add(café);
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

        // GET: Cafés/Edit/5
        public ActionResult Edit(string id, string message = "")
        {
            var user = db.Cafés.Where(
                u => u.IDcafé == id).FirstOrDefault();
            ViewBag.errorMessage = message;
            return View(user);
        }

        // POST: Cafés/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include =
            "IDcafé,Nombre,Regular, Grande,Rocas, Frappe, FechaModificacion")]Cafés café)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    café.FechaModificacion = DateTime.Now;
                    db.Entry(café).State = EntityState.Modified;
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

        // GET: Cafés/Delete/5
        public ActionResult Delete(string id)
        {
            var café = db.Cafés.Where(
                u => u.IDcafé == id).FirstOrDefault();
            return View(café);
        }

        // POST: Cafés/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete([Bind(Include =
            "IDcafé,Nombre,Regular, Grande,Rocas, Frappe, FechaModificacion")]Cafés café)
        {
            try
            {
                var lastRecord = db.Cafés.Where
                  (u => u.IDcafé == café.IDcafé).FirstOrDefault();
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(lastRecord).State = EntityState.Deleted;
                    db.Cafés.Remove(lastRecord);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", new { message = "Café Eliminado" });
                }
                return RedirectToAction("Index", new { message = "Error" });
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                return RedirectToAction("Index", new { message = "Error: " + exception });
            }
        }
    }
}
