using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgra4.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult Reportes()
        {
            return View();
        }

        public ActionResult PrintReportsClientes()
        {
            return new ActionAsPdf("ReporteClientes", new { name = "Clientes" }) { FileName = "Reporte Clientes.pdf" };
        }

        public ActionResult ReporteClientes(string name)
        {
            ViewBag.Message = string.Format("Hello {0} to ASP.NET MVC!", name);

            using (var BaseDatos = new ProyectoEntities())
            {
                var clientes = (from x in BaseDatos.Clientes
                                select x).ToList();

                return View(clientes);
            }


        }
    }
}