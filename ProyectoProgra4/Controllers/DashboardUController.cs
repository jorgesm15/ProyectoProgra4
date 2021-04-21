using System.Web.Mvc;

namespace ProyectoProgra4.Controllers
{
    public class DashboardUController : Controller
    {
        // GET: DashboardU
        public ActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
    }
}