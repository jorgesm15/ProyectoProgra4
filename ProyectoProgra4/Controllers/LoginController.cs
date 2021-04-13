using ProyectoProgra4.Entidades;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace ProyectoProgra4.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(clsLogin usuario)
        {
            //if (ModelState.IsValid)
            //{
                using (var login = new ProyectoEntities())
                {
                    var contraseniaHash = GetMD5(usuario.contrasenia);
                    var user = login.Clientes.Where(query => query.Correo.Equals(usuario.correo) && query.Contraseña.Equals(contraseniaHash)).SingleOrDefault();

                    try
                    {
                        if (user != null)
                        {
                            Session["UserCorreo"] = user.Correo.ToString();
                            Session["Nombre"] = user.Nombre.ToString();
                            return RedirectToAction("Index", "DashboardU");
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception e)
                    {
                        if (e.GetType().Name == "Exception")
                        {
                            if (user == null)
                            {
                                ViewBag.Error = "El correo electrónico que ingresaste no existe.";

                            }

                        }
                    }

                }
            //}
            return View("Index");
        }

    
        public ActionResult CerrarSession()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("PaginaPrincipal", "PaginaPrincipal");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }



}