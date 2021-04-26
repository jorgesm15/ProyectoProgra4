using ProyectoProgra4.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoProgra4.Controllers
{
    public class AdministrarInstructorController : Controller
    {

        public ActionResult Index()
        {
            using (var contexto = new ProyectoEntities())
            {
                var instructores = (from x in contexto.Instructor.AsEnumerable()
                                    join d in contexto.Disciplinas.AsEnumerable()
                                    on x.ID_Especialidad equals d.claseID
                                    join a in contexto.Administrador.AsEnumerable()
                                    on x.ID_Administrador equals a.ID_Administrador
                                    select new Instructor()
                                    {
                                        ID_Instructor = x.ID_Instructor,
                                        Nombre = x.Nombre,
                                        PrimerApellido = x.PrimerApellido,
                                        SegundoApellido = x.SegundoApellido,
                                        Correo = x.Correo,
                                        Telefono = x.Telefono,
                                        TelefonoEmergencia = x.TelefonoEmergencia,
                                        Edad = x.Edad,
                                        CondicionesMedicas = x.CondicionesMedicas,
                                        nombreDis = d.nombre,
                                        nombreAdm = a.Nombre
                                    }).ToList();

                Session["VerInstructores"] = instructores;
                ViewBag.Message = TempData["MsjInstructor"];
                CargarEspecialidad();
                return View();
            }
        }

        //public ActionResult ValidarBoton(clsInstructor instructor, string submit)
        //{
        //    if (submit == "Reservar")
        //    {
        //        //InsertarReserva(reserva);
        //        //Reserva();
        //        //return View("Reserva");
        //    }
        //    else if (submit == "Guardar Cambios")
        //    {
        //        ActualizarCambios(reserva);
        //        return View("Reserva");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        public void CargarEspecialidad()
        {
            using (var contexto = new ProyectoEntities())
            {
                var respuesta = (from x in contexto.Disciplinas select x).ToList();
                List<SelectListItem> listilla = new List<SelectListItem>();

                foreach (var item in respuesta)
                {
                    listilla.Add(new SelectListItem { Value = item.claseID.ToString(), Text = item.nombre });
                }

                ViewBag.ListaComboEspecialidad = listilla;
            }
        }


        public ActionResult ActualizarDatosInstructor(string instructorId) //Cargar Datos en la parte de mostrar vista reserva
        {
            using (var contexto = new ProyectoEntities())
            {

                var instructores = (from x in contexto.Instructor
                                    where x.ID_Instructor == instructorId
                                    select x).FirstOrDefault();

                Dictionary<String, String> reserva = new Dictionary<string, string>();


                reserva.Add("ID_Instructor", instructores.ID_Instructor);
                reserva.Add("Nombre", instructores.Nombre);
                reserva.Add("PrimerApellido", instructores.PrimerApellido);
                reserva.Add("SegundoApellido", instructores.SegundoApellido);
                reserva.Add("Correo", instructores.Correo);
                reserva.Add("Edad", instructores.Edad.ToString());
                reserva.Add("Telefono", instructores.Telefono);
                reserva.Add("TelefonoEmergencia", instructores.TelefonoEmergencia);
                reserva.Add("CondicionesMedicas", instructores.CondicionesMedicas);
                reserva.Add("Especialidad", instructores.ID_Especialidad.ToString());

                if (instructores.ID_Instructor != instructorId)
                {
                    return Json(null, JsonRequestBehavior.DenyGet);
                }
                else
                {
                    return Json(reserva, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult ActualizarInstructor(clsInstructor instructor)
        {
            if (ModelState.IsValid)
            {
                using (var contexto = new ProyectoEntities())
                {
                    var ID_Administrador = Convert.ToInt32(Session["ID_Admin"]);
                    var respuesta = (from x in contexto.Instructor
                                     where x.ID_Instructor == instructor.cedula
                                     select x).FirstOrDefault();
                    if (respuesta != null)
                    {
                        respuesta.ID_Instructor = instructor.cedula;
                        respuesta.Nombre = instructor.nombre;
                        respuesta.PrimerApellido = instructor.primerApellido;
                        respuesta.SegundoApellido = instructor.segundoApellido;
                        respuesta.Correo = instructor.correo;
                        respuesta.Edad = instructor.edad;
                        respuesta.Telefono = instructor.telefono;
                        respuesta.TelefonoEmergencia = instructor.telefonoEmergencia;
                        respuesta.CondicionesMedicas = instructor.condicionesMedicas;
                        respuesta.ID_Especialidad = instructor.especialidad;
                        respuesta.ID_Administrador = ID_Administrador;
                        contexto.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            CargarEspecialidad();
            return View("Index");
        }

        public ActionResult EliminarInstructor(string instructorId)
        {
            using (var contexto = new ProyectoEntities())
            {
                var instructores = (from x in contexto.Instructor
                                    where x.ID_Instructor == instructorId
                                    select x).FirstOrDefault();

                if (instructores != null)
                {
                    contexto.Instructor.Remove(instructores);
                    contexto.SaveChanges();
                    CargarEspecialidad();
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }
    }

}

