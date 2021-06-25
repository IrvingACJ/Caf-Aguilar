using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MVCTemplate.Models;

namespace MVCTemplate.Controllers
{
    public class EstadisticasController : Controller
    {
        ModelCaféAguilarDB db = new ModelCaféAguilarDB();
        // GET: Estadisticas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getTopCafes(DateTime inicio, DateTime fin)
        {
            fin = new DateTime(fin.Year, fin.Month, fin.Day, 23, 59, 59);
            var arry = new List<Tuple<string,int>>();
            using (var conn = new SqlConnection(db.Database.Connection.ConnectionString) )
            {
                conn.Open();
                using (var cmmnd = new SqlCommand("SP_TopVentaCafe",conn))
                {
                    cmmnd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmmnd.Parameters.Add(new SqlParameter("fechaInicio", inicio));
                    cmmnd.Parameters.Add(new SqlParameter("fechaFin", fin));
                    using (var reader = cmmnd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            arry.Add(new Tuple<string, int>(reader["Nombre"].ToString(), int.Parse(reader["Cantidad"].ToString())));
                        }
                    }
                }
            }
            return Json(arry, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getTopPostres(DateTime inicio, DateTime fin)
        {
            fin = new DateTime(fin.Year, fin.Month, fin.Day, 23, 59, 59);

            var arry = new List<Tuple<string, int>>();
            using (var conn = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                conn.Open();
                using (var cmmnd = new SqlCommand("SP_TopVentaPostres", conn))
                {
                    cmmnd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmmnd.Parameters.Add(new SqlParameter("fechaInicio", inicio));
                    cmmnd.Parameters.Add(new SqlParameter("fechaFin", fin));
                    using (var reader = cmmnd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            arry.Add(new Tuple<string, int>(reader["Nombre"].ToString(), int.Parse(reader["Cantidad"].ToString())));
                        }
                    }
                }
            }
            return Json(arry, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ventasFechas(DateTime inicio, DateTime fin)
        {
            fin = new DateTime(fin.Year, fin.Month, fin.Day, 23, 59, 59);

            int postres = 0, cafes = 0;
            using (var conn = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                conn.Open();
                using (var cmmnd = new SqlCommand("SP_PostresFechas", conn))
                {
                    cmmnd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmmnd.Parameters.Add(new SqlParameter("fechaInicio", inicio));
                    cmmnd.Parameters.Add(new SqlParameter("fechaFin", fin));
                    

                    using (var reader = cmmnd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            postres = int.Parse(reader["Total"].ToString());
                        };
                    }
                }
                using (var cmmnd = new SqlCommand("SP_CafeFecha", conn))
                {
                    cmmnd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmmnd.Parameters.Add(new SqlParameter("fechaInicio", inicio));
                    cmmnd.Parameters.Add(new SqlParameter("fechaFin", fin));


                    using (var reader = cmmnd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cafes = int.Parse(reader["Total"].ToString());
                        };
                    }
                }
            }

            return Json(new { Cafe = cafes, Postre = postres }, JsonRequestBehavior.AllowGet);
        }
    }
}