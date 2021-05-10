using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCTemplate.Models;
using System.Globalization;
using System.Web.Security;
using MVCTemplate.Class;

namespace MVCTemplate.Controllers
{
    [Authorize]
    public class UsersExamples : Controller
    {
        /*
        ModelBD db = new ModelBD();

        // GET: Users
        public ActionResult Index()
        {
            var users = db..ToList();
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            var user = db.T_TEMPLATE_USERS.Where(
                u => u.USER_ID == id).FirstOrDefault();

            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create(string message = "")
        {
            ViewBag.ROLE_ID = new SelectList(db.T_TEMPLATE_ROLES.ToList(),
                "ROLE_ID", "ROLE");
            ViewBag.errorMessage = message;

            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include =
            "USER_ID,ROLE_ID,WIN_USER,NAME,MAIL")] T_TEMPLATE_USERS user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lastRecord = db.T_TEMPLATE_USERS.OrderByDescending
                      (u => u.USER_ID).FirstOrDefault();
                    user.USER_ID = ((lastRecord == null) || 
                        (lastRecord.USER_ID == 0))
                        ? 1 : lastRecord.USER_ID + 1;

                    db.T_TEMPLATE_USERS.Add(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Users");
                }
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                return RedirectToAction("Index", new { message = "Error: "+exception });
            }
            return View();
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id,string message="")
        {
            var user = db.T_TEMPLATE_USERS.Where(
                u => u.USER_ID == id).FirstOrDefault();
            ViewBag.ROLE_ID = new SelectList(db.T_TEMPLATE_ROLES.ToList(),
                "ROLE_ID", "ROLE");
            ViewBag.errorMessage = message;
            
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include =
            "USER_ID,ROLE_ID,WIN_USER,NAME,MAIL")]T_TEMPLATE_USERS user)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
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

        // POST: Users/Delete/5

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var user = db.T_TEMPLATE_USERS.Where(
                u => u.USER_ID == id).FirstOrDefault();
                db.T_TEMPLATE_USERS.Remove(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { message = "Usuario Eliminado" });
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
                return RedirectToAction("Index", new { message = "Error: " + exception });
            }
        }
        */
    }
}
