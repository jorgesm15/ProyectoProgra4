using ProyectoProgra4.Entidades;
using System;
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
            if (ModelState.IsValid)
            {
                using (var login = new ProyectoEntities())
                {
                    var contraseniaHash = GetMD5(usuario.contrasenia);
                    var user = login.Clientes.Where(query => query.Correo.Equals(usuario.correo) && query.Contraseña.Equals(contraseniaHash)).SingleOrDefault();
                    var admin = login.Administrador.Where(query => query.Correo.Equals(usuario.correo) && query.Contraseña.Equals(contraseniaHash) && query.Rol.Equals("Administrador")).SingleOrDefault();
                    var instructor = login.Instructor.Where(query => query.Correo.Equals(usuario.correo) && query.Contraseña.Equals(contraseniaHash) && query.Rol.Equals("Instructor")).SingleOrDefault();
                    try
                    {
                        if (user != null)
                        {
                            Session["UserCorreo"] = user.Correo.ToString();
                            Session["Nombre"] = user.Nombre.ToString();
                            Session["Rol"] = user.Rol.ToString();
                            Session["ID_Usuario"] = user.ID_Cliente.ToString();
                            Session["ID_Sexo"] = user.ID_Sexo.ToString();
                            return RedirectToAction("Index", "DashboardU");
                        }
                        else if (admin != null)
                        {
                            Session["UserCorreo"] = admin.Correo.ToString();
                            Session["Nombre"] = admin.Nombre.ToString();
                            Session["Rol"] = admin.Rol.ToString();
                            Session["ID_Admin"] = admin.ID_Administrador;
                            //Session["ID_Sexo"] = admin..ToString();
                            return RedirectToAction("Administrador", "Administrador");
                        }else if(instructor != null)
                        {
                            Session["UserCorreo"] = instructor.Correo.ToString();
                            Session["Nombre"] = instructor.Nombre.ToString();
                            Session["Rol"] = instructor.Rol.ToString();
                            Session["ID_Instructor"] = instructor.ID_Instructor;
                            Session["ID_Especialidad"] = instructor.ID_Especialidad;
                            Session["ID_Sexo"] = instructor.ID_Sexo.ToString();
                            return RedirectToAction("Index", "DashboardI");
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
                                DateTime dateTime = DateTime.Now;
                                using (var contextoUsuario = new ProyectoEntities())
                                {
                                    contextoUsuario.InsertarErrores(
                                       e.Message.ToString(), usuario.correo, dateTime
                                    );
                                }

                            }

                        }
                    }

                }
            }
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