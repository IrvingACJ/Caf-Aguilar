using MVCTemplate.Class;
using MVCTemplate.Models;
using Newtonsoft.Json;
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
        ModelCaféAguilarDB db = new ModelCaféAguilarDB();
        ClsPwd PWD = new ClsPwd();
        public ActionResult Index()
        {
            var users = db.Usuarios.ToList();
            return View(users);
        }
        public ActionResult GetPermits()
        {
            var permits = from entry in db.Permisos.AsEnumerable()
                      select new
                      {
                          entry.IDpermiso,
                          entry.Permiso
                      };
            var json = JsonConvert.SerializeObject(permits.ToList(), Formatting.None);
            return Json(json);
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
        public ActionResult Create2(string nombre, string contrase_a, string permisos)
        {
            var ArrayPermisos = permisos.Split(',');
            var lastRecord = db.Usuarios.OrderByDescending(u => u.IDusuario).FirstOrDefault();
            var New_User= new Usuarios();
            try
            {
                New_User.IDusuario = ((lastRecord == null) ||
                    (lastRecord.IDusuario == 0))
                    ? 1 : lastRecord.IDusuario + 1;
                New_User.Nombre = nombre;
                New_User.Contraseña = PWD.Encriptar(contrase_a);
                db.Usuarios.Add(New_User);
                db.SaveChanges();
                foreach (var permiso in ArrayPermisos)
                {
                    int PermisoID = Convert.ToInt32(permiso);
                    int? x = null;
                    var existente = db.Permisos_Usuarios.Where(p => p.IDpermiso == PermisoID).Where(u => u.IDusuario == New_User.IDusuario).FirstOrDefault();
                    if (existente == null)
                    {
                        var New_Permiso = new Permisos_Usuarios();
                        var lastRecordPU = db.Permisos_Usuarios.OrderByDescending(u => u.ID).FirstOrDefault();
                        New_Permiso.ID = ((lastRecordPU == null) ||
                            (lastRecordPU.ID == 0))
                            ? 1 : lastRecordPU.ID+ 1;
                        New_Permiso.IDusuario = New_User.IDusuario;
                        New_Permiso.IDpermiso = Convert.ToInt32(permiso);
                        db.Permisos_Usuarios.Add(New_Permiso);
                        db.SaveChanges();
                    }
                }
                return Content(Url.Action("Index", new { message = "Café Agregado" }));

            }
            catch (Exception ex)
            {
                return View("Error: " + ex);
            }
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
