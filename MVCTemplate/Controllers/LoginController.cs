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

namespace ComcellGeneratorCVI.Controllers
{
    public class LoginController : Controller
    {
        //TemplateDbContext db = new TemplateDbContext();
        WindowsUser ActiveDirectory = new WindowsUser();
        /// <summary>
        /// Open Login view
        /// </summary>
        /// <returns>login view and error message in view bag</returns>
        // GET: Login
        public ActionResult Index(string message = "")
        {
            //Return Error Message
            ViewBag.errorMessage = message;
            return View();
        }
        /// <summary>
        /// Login logic
        /// </summary>
        /// <param name="username">windows user</param>
        /// <param name="password">windows password</param>
        /// <returns>Home index view</returns>
        //POST: Login/Signin
        [HttpPost]
        public ActionResult Signin(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                /*
                //Windows user model
                WindowsUserViewModel AD_User = ActiveDirectory.FindUser(username, password);
                //App user model
                var user = new T_TEMPLATE_USERS();
                //Validate if user excists
                if (AD_User != null)
                {
                    //create object with logged user
                    var loginUser = db.T_TEMPLATE_USERS.Where(u => u.WIN_USER == AD_User.WindowsUser).FirstOrDefault();
                    if (loginUser == null)
                    {
                        var lastRecord = db.T_TEMPLATE_USERS.OrderByDescending(
                        u => u.USER_ID).FirstOrDefault();
                        loginUser = new T_TEMPLATE_USERS();
                        loginUser.USER_ID = ((lastRecord == null) || (lastRecord.USER_ID == 0))
                            ? 1 : lastRecord.USER_ID + 1;
                        loginUser.WIN_USER = AD_User.WindowsUser;
                        loginUser.NAME = AD_User.Name;
                        db.T_TEMPLATE_USERS.Add(loginUser);
                        db.SaveChanges();
                        
                    }

                    user = loginUser;
                }
                if (string.IsNullOrEmpty(user.WIN_USER))
                {
                    //Return error message
                    return RedirectToAction("Index", new { message = "User not Found" });
                }
                else
                {
                    //Return view with user authentication 
                    FormsAuthentication.SetAuthCookie(user.WIN_USER, true);
                    return RedirectToAction("Index", "Home");
                }
                */
                return RedirectToAction("Index", new { message = "Insert username and/or password" });
            }
            else
            {
                //return message for empty user
                return RedirectToAction("Index", new { message = "Insert username and/or password" });
            }

        }
        /// <summary>
        /// logout logic
        /// </summary>
        /// <returns>login view</returns>
        //POST: Login/Logout
        [Authorize]
        public ActionResult Logout()
        {
            //Finish session 
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}