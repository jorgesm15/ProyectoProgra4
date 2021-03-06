using ProyectoProgra4.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;

namespace ProyectoProgra4.Controllers
{
    public class ReservarController : Controller
    {
        // GET: Reservar

        public ActionResult Reserva()
        {
            try
            {
                using (var contexto = new ProyectoEntities())
                {
                    var reservas = (from x in contexto.Reserva.AsEnumerable()
                                    join d in contexto.Disciplinas.AsEnumerable()
                                    on x.claseID equals d.claseID
                                    where x.ID_Cliente == Session["ID_Usuario"].ToString()  
                                    select new Reserva()
                                    {
                                        reservaID = x.reservaID,
                                        nombreDis = d.nombre,
                                        dia = x.dia,
                                        hora = x.hora,
                                        equipo = x.equipo
                                    }).ToList();

                    CargarDisciplinas(); //se trae las disciplinas al drop-down
                    Session["mostrarReservas"] = reservas;
                    return View("Reserva");
                }
            }
            catch (Exception e)
            {
                DateTime dateTime = DateTime.Now;
                using (var contextoUsuario = new ProyectoEntities())
                {
                    contextoUsuario.InsertarErrores(
                       e.Message.ToString(), Session["ID_Usuario"].ToString(), dateTime
                    );
                }

            }

            CargarDisciplinas(); //se trae las disciplinas al drop-down
            return View("Reserva");


        }


        public void CargarDisciplinas() //se trae las disciplinas al drop-down
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
        public ActionResult ValidarBoton(clsReserva reserva, string submit)
        {
            try
            {
                if (submit == "Reservar")
                {
                    InsertarReserva(reserva);
                    Reserva();
                    return View("Reserva");

                }
                else if (submit == "Guardar Cambios")
                {
                    ActualizarCambios(reserva);
                    Reserva();
                    return View("Reserva");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                DateTime dateTime = DateTime.Now;
                using (var contextoUsuario = new ProyectoEntities())
                {
                    contextoUsuario.InsertarErrores(
                       e.Message.ToString(), Session["ID_Usuario"].ToString(), dateTime
                    );
                }

            }
            return RedirectToAction("Index", "Home");

        }

        public void InsertarReserva(clsReserva reserva) // Ejecuta el procedimiento almancenado de Insertar
        {
            try
            {
                using (var contextoReservar = new ProyectoEntities())
                {
                    int resultado = contextoReservar.RegistrarReserva(
                        reserva.claseID, reserva.dia, reserva.hora, reserva.equipo, Session["ID_Usuario"].ToString()
                    );

                    if (resultado == -1)
                    {
                        ViewBag.ErrorReserva = "Reserva Duplicada";
                    }
                }

            }
            catch (Exception e)
            {

                ViewBag.ErrorReserva = "Reserva Duplicada";
                DateTime dateTime = DateTime.Now;
                using (var contextoUsuario = new ProyectoEntities())
                {
                    contextoUsuario.InsertarErrores(
                       e.Message.ToString(), Session["ID_Usuario"].ToString(), dateTime
                    );
                }

            }
        }


        [HttpPost]
        public ActionResult EliminarReserva(int reservaID)
        {
            try
            {
                using (var contexto = new ProyectoEntities())
                {
                    var reservas = (from x in contexto.Reserva
                                    where x.reservaID == reservaID
                                    select x).FirstOrDefault();

                    if (reservas != null)
                    {
                        contexto.Reserva.Remove(reservas);
                        contexto.SaveChanges();
                        return RedirectToAction("Reserva");

                    }

                    return View("Reserva");
                }
            }
            catch (Exception e)
            {
                DateTime dateTime = DateTime.Now;
                using (var contextoUsuario = new ProyectoEntities())
                {
                    contextoUsuario.InsertarErrores(
                       e.Message.ToString(), Session["ID_Usuario"].ToString(), dateTime
                    );
                }

            }
            return View("Reserva");
        }

        [HttpPost]
        public ActionResult ActualizarDatos(int reservaID) //Cargar Datos en la parte de mostrar vista reserva
        {
            try
            {
                using (var contexto = new ProyectoEntities())
                {

                    var reservas = (from x in contexto.Reserva
                                    where x.reservaID == reservaID
                                    select x).FirstOrDefault();

                    Dictionary<String, String> reserva = new Dictionary<string, string>();


                    reserva.Add("claseID", reservas.claseID.ToString());
                    reserva.Add("hora", reservas.hora.ToString() + " PM");
                    reserva.Add("dia", reservas.dia.ToString().Split(' ')[0]);
                    reserva.Add("reservaID", reservas.reservaID.ToString());


                    if (reservas.reservaID != reservaID)
                    {
                        return Json(null, JsonRequestBehavior.DenyGet);
                    }
                    else
                    {
                        return Json(reserva, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception e)
            {
                DateTime dateTime = DateTime.Now;
                using (var contextoUsuario = new ProyectoEntities())
                {
                    contextoUsuario.InsertarErrores(
                       e.Message.ToString(), Session["ID_Usuario"].ToString(), dateTime
                    );
                }

                return RedirectToAction("Index", "Home");


            }



        }

        public void ActualizarCambios(clsReserva reserva) //Cargar los datos 
        {
            using (var contextoReservar = new ProyectoEntities())
            {
                int resultado = contextoReservar.ActualizarReserva(
                    reserva.reservaID, reserva.claseID, reserva.dia, reserva.hora, reserva.equipo, Session["ID_Usuario"].ToString()
                );

                if (resultado == -1)
                {
                    ViewBag.ErrorReserva = "Reserva Duplicada";
                }
            }



        }
    }

}

