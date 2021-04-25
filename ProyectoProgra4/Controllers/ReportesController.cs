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
            
            using (var BaseDatos = new ProyectoEntities())
            {
                var clientes = (from x in BaseDatos.Clientes
                                select x).ToList();

                return View(clientes);
            }


        }

        public ActionResult PrintReportsInstructores()
        {
            return new ActionAsPdf("ReporteInstructores", new { name = "Instructores" }) { FileName = "Reporte Instructores.pdf" };
        }

        public ActionResult ReporteInstructores(string name)
        {
            using (var BaseDatos = new ProyectoEntities())
            {
                var instructores = (from x in BaseDatos.Instructor
                                select x).ToList();

                return View(instructores);
            }


        }


        public ActionResult PrintReportsReservas()
        {
            return new ActionAsPdf("ReporteReservas", new { name = "Reservas" }) { FileName = "Reporte Reservas.pdf" };
        }

        public ActionResult ReporteReservas(string name)
        {
            using (var BaseDatos = new ProyectoEntities())
            {
                var reservas = (from x in BaseDatos.Reserva
                                    select x).ToList();

                return View(reservas);
            }


        }

        public ActionResult PrintReportsBitacora()
        {
            return new ActionAsPdf("ReporteBitacora", new { name = "Bitacora" }) { FileName = "Reporte Bitacora.pdf" };
        }

        public ActionResult ReporteBitacora(string name)
        {
            using (var BaseDatos = new ProyectoEntities())
            {
                var bitacora = (from x in BaseDatos.Errores
                                select x).ToList();

                return View(bitacora);
            }


        }
    }
}