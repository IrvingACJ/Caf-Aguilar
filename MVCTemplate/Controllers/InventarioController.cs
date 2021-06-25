using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCTemplate.Models;

namespace MVCTemplate.Controllers
{
    public class InventarioController : Controller
    {
        ModelCaféAguilarDB db = new ModelCaféAguilarDB();
        // GET: Inventario
        public ActionResult Index()
        {
            var inventario = db.Inventario_Productos.ToList();
            return View(inventario);
        }

        public ActionResult Delete(int Id)
        {
            var producto = db.Inventario_Productos.Where(i => i.IDproducto == Id).FirstOrDefault();
            return View(producto);
        }
        [HttpPost]
        public async Task<ActionResult> Delete([Bind(Include =
            "IDproducto")]Inventario_Productos inventario_Productos)
        {
            try
            {
                var obj = db.Inventario_Productos.Where(
                    u => u.IDproducto == inventario_Productos.IDproducto).FirstOrDefault();
                // TODO: Add update logic here

                db.Entry(obj).State = EntityState.Deleted;
                db.Inventario_Productos.Remove(obj);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { message = "Producto Eliminado" });
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                return RedirectToAction("Index", new { message = "Error: " + exception });
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include =
            "IDproducto, Nombre, Precio, Cantidad, Minimo")]Inventario_Productos inventario_Productos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lastRecord = db.Inventario_Productos.OrderByDescending
                      (u => u.IDproducto).FirstOrDefault();
                    inventario_Productos.IDproducto = ((lastRecord == null) ||
                        (lastRecord.IDproducto == 0))
                        ? 1 : lastRecord.IDproducto + 1;
                    db.Inventario_Productos.Add(inventario_Productos);
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

        public ActionResult Edit(int Id)
        {
            var producto = db.Inventario_Productos.Where(i => i.IDproducto == Id).FirstOrDefault();
            return View(producto);
        }
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include =
             "IDproducto, Nombre, Precio, Cantidad, Minimo")]Inventario_Productos inventario_Productos)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(inventario_Productos).State = EntityState.Modified;
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
    }
}