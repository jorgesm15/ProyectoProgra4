using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgra4.Controllers
{
    public class ReservarController : Controller
    {
        // GET: Reservar
        public ActionResult Reserva()
        {
            using (var contexto = new ProyectoEntities1())
            {
                var respuesta = (from x in contexto.Disciplinas select x).ToList();

                return View(respuesta);
            }

          
        }

        //[HttpPost]
        //public ActionResult ObtenerDisciplinas()
        //{
        //    //using (var contexto = new ProyectoEntities())
        //    //{
        //    //    var respuesta = (from x in contexto.Disciplinas select x).ToList(); 

        //    //    return View("Reserva", respuesta);
        //    //}
        //}

    }
}