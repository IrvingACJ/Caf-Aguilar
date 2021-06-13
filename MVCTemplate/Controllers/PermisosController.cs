using MVCTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTemplate.Controllers
{
    public class PermisosController : Controller
    {
        // GET: Cafés
        ModelCaféAguilarDB db = new ModelCaféAguilarDB();
        // GET: Permisoss
        public ActionResult Index()
        {
            var permisos = db.Permisos.ToList();
            return View(permisos);
        }
    }
}
