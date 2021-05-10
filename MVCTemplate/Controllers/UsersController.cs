using MVCTemplate.Class;
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
    public class UsersController : Controller
    {
        // GET: Users
        ModelBD db = new ModelBD();
        ClsPwd PWD = new ClsPwd();
        public ActionResult Index()
        {
            var users = db.Usuarios.ToList();
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            var user = db.Usuarios.Where(
                u => u.IDusuario == id).FirstOrDefault();
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include =
            "IDusuario,Nombre,Contraseña")] Usuarios user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lastRecord = db.Usuarios.OrderByDescending
                      (u => u.IDusuario).FirstOrDefault();
                    user.IDusuario = ((lastRecord == null) ||
                        (lastRecord.IDusuario == 0))
                        ? 1 : lastRecord.IDusuario + 1;
                    user.Contraseña = PWD.Encriptar(user.Contraseña);
                    db.Usuarios.Add(user);
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

        // GET: Users/Edit/5
        public ActionResult Edit(int id, string message = "")
        {
            var user = db.Usuarios.Where(
                u => u.IDusuario == id).FirstOrDefault();
            user.Contraseña = PWD.DesEncriptar(user.Contraseña);
            ViewBag.errorMessage = message;
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include =
            "IDusuario,Nombre,Contraseña")]Usuarios user)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    user.Contraseña = PWD.Encriptar(user.Contraseña);
                    db.Entry(user).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Users");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                return RedirectToAction("Index", new { message = "Error: " + exception });
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            var user = db.Usuarios.Where(
                u => u.IDusuario == id).FirstOrDefault();
            return View(user);
        }

        // POST: Users/Delete/5

        [HttpPost]
        public async Task<ActionResult> Delete([Bind(Include =
            "IDusuario,Nombre,Contraseña")]Usuarios user)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Deleted;
                    db.Usuarios.Remove(user); 
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", new { message = "Usuario Eliminado" });
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
