using ProyectoProgra4.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgra4.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Administrador()
        {
            return View();
        }
    }
}