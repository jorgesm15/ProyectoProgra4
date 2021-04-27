using ProyectoProgra4.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgra4.Controllers
{
    public class RutinaController : Controller
    {
        // GET: Rutina
        public ActionResult Index()
        {

            using (var contexto = new ProyectoEntities())
            {
                var rutinas = (from x in contexto.Rutinas.AsEnumerable()
                                 select new Rutinas()
                                 {
                                     ID_Ejercicio = x.ID_Ejercicio,
                                     NomEjercicio = x.NomEjercicio,
                                     Duracion = x.Duracion,
                                     Series = x.Series,
                                     Repeticion = x.Repeticion,
                                     Descanso = x.Descanso
                                 }).ToList();
                Session["VerRutinas"] = rutinas;
                return View();
            }
        }



        public ActionResult ActualizarDatos(int ID_Ejercicio)
        {
            using (var contexto = new ProyectoEntities())
            {

                var rutinas = (from x in contexto.Rutinas
                               where x.ID_Ejercicio == ID_Ejercicio
                               select x).FirstOrDefault();

                Dictionary<string, string> rutina = new Dictionary<string, string>();

                rutina.Add("ID_Ejercicio", rutinas.ID_Ejercicio.ToString());
                rutina.Add("NomEjercicio", rutinas.NomEjercicio);
                rutina.Add("Duracion", rutinas.Duracion.ToString());
                rutina.Add("Series", rutinas.Series.ToString());
                rutina.Add("Repeticion", rutinas.Repeticion);
                rutina.Add("Descanso", rutinas.Descanso);

                if (rutinas.ID_Ejercicio != ID_Ejercicio)
                {
                    return Json(null, JsonRequestBehavior.DenyGet);
                }
                else
                {
                    return Json(rutina, JsonRequestBehavior.AllowGet);
                }
            }
        }


        public ActionResult ActualizarRutina(clsRutina rutina)
        {
            using (var contexto = new ProyectoEntities())
            {
                //var ID_Administrador = Convert.ToInt32(Session["ID_Admin"]);
                var respuesta = (from x in contexto.Rutinas
                                 where x.ID_Ejercicio == rutina.ID_Ejercicio
                                 select x).FirstOrDefault();
                if (respuesta != null)
                {
                    respuesta.ID_Ejercicio = rutina.ID_Ejercicio;
                    respuesta.NomEjercicio = rutina.nomEjercicio;
                    respuesta.Duracion = rutina.duracion;
                    respuesta.Series = rutina.series;
                    respuesta.Repeticion = rutina.repeticion;
                    respuesta.Descanso = rutina.descanso;
                    contexto.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }


    }
}