using System.Web.Mvc;


namespace ProyectoProgra4.Controllers
{
    public class PaginaPrincipalController : Controller
    {
        // GET: PaginaPrincipal
        [HttpGet]
        public ActionResult PaginaPrincipal()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
    }
}