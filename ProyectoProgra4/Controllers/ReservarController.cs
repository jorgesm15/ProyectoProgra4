using ProyectoProgra4.Entidades;
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
            using (var contexto = new ProyectoEntities())
            {
                //var reservas = (from x in contexto.Reserva select x).ToList();
                var reservas = (from x in contexto.Reserva.AsEnumerable()
                                join d in contexto.Disciplinas.AsEnumerable()
                        on x.claseID equals d.claseID
                        select new Reserva()
                        {
                            nombreDis = d.nombre,
                            dia = x.dia,
                            hora = x.hora,
                            equipo = x.equipo
                        }).ToList();
                 

                CargarDisciplinas();

               
                Session["mostrarReservas"] = reservas;
                return View("Reserva");
            }

        }


        public void CargarDisciplinas()
        {
            using (var contexto = new ProyectoEntities())
            {
                var respuesta = (from x in contexto.Disciplinas select x).ToList();
                List<SelectListItem> listilla = new List<SelectListItem>();

                foreach (var item in respuesta)
                {
                    listilla.Add(new SelectListItem { Value = item.claseID.ToString(), Text = item.nombre });
                }


                ViewBag.ListaComboDis = listilla;
            }
        }

        [HttpPost]
        public ActionResult InsertarReserva(clsReserva reserva)
        {
            using (var contextoReservar = new ProyectoEntities())
            {
                contextoReservar.RegistrarReserva(
                    reserva.claseID, reserva.dia, reserva.hora, reserva.equipo, "117800977"
                ) ;
            }

            Reserva();

            return View("Reserva");
        }       
    }
}