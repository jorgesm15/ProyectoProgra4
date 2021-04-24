using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoProgra4.Controllers
{
    public class RutinaController : Controller
    {

        [HttpPost]
        public void VerRutina()
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

        public ActionResult Rutina()
        {
            VerRutina();

            return View();
        }
    }
}