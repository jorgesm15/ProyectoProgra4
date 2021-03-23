using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ProyectoProgra4.ActionFilter.NoDirectAccess;

namespace ProyectoProgra4.Controllers
{
    public class PaginaPrincipalController : Controller
    {
        // GET: PaginaPrincipal
        [HttpGet]
        public ActionResult PaginaPrincipal()
        {
            return View();
        }
    }
}