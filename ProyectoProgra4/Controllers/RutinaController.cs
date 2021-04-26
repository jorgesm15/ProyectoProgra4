using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoProgra4.Controllers
{
    public class RutinaController : Controller
    {

        [HttpPost]
        public void Rutina()
        {
            using (var contexto = new ProyectoEntities())
            {
                var respuesta = (from x in contexto.Motivo select x).ToList();
                List<SelectListItem> listilla = new List<SelectListItem>();

                foreach (var item in respuesta)
                {
                    listilla.Add(new SelectListItem { Value = item.ID_Motivo.ToString(), Text = item.Descripcion });
                }


                ViewBag.ListaComboDis = listilla;
            }
        }

        public ActionResult RutinasParcial()
        {
            Rutina();

            return View();
        }

        public ActionResult ActualizarRutina(int ID_Ejercicio)
        {
            using (var contexto = new ProyectoEntities())
            {

                var rutinas = (from x in contexto.Rutinas
                                    where x.ID_Ejercicio == ID_Ejercicio
                                    select x).FirstOrDefault();

                Dictionary<string, string> rutina = new Dictionary<string, string>();

                rutina.Add("nomEjercicio", rutinas.NomEjercicio);
                rutina.Add("duracion", rutinas.Duracion.ToString());
                rutina.Add("series", rutinas.Series.ToString());
                rutina.Add("repeticion", rutinas.Repeticion);
                rutina.Add("descanso", rutinas.Descanso);

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
    }
}