using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoProgra4.Entidades;

namespace ProyectoProgra4.Controllers
{
    public class RutinasController : Controller
    {
        [HttpGet]
        public ActionResult Rutinas()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertarReserva(clsRutinas rutina)
        {
            using (var contextoRutinas = new ProyectoEntities1())
            {
                contextoRutinas.VerRutinas(
                    rutina.id_rutina, rutina.descripcion);
            }

            Rutinas();

            return View("Rutinas");
        }
    }
}