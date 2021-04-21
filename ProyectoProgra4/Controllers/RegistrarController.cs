using ProyectoProgra4.Entidades;
using ProyectoProgra4.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;


namespace ProyectoProgra4.Controllers
{
    public class RegistrarController : Controller
    {
        // GET: Registrar
        public ActionResult Index()
        {
            CargarEspecialidad();
            CargarSexo();
            CargarTipoSangre();
            return View("InsertarUsuario");
        }

        public ActionResult InsertarUsuario(clsUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var contextoUsuario = new ProyectoEntities())
                    {
                        var rol = "Cliente";
                        contextoUsuario.InsertarClientes(
                            usuario.cedula, usuario.nombre, usuario.primerApellido, usuario.segundoApellido,
                            usuario.correo, usuario.edad, GetMD5(usuario.contrasenia), usuario.direccion, usuario.telefono,
                            usuario.telefonoEmergencia, usuario.peso, usuario.estatura, usuario.condicionesMedicas, usuario.motivo, rol, usuario.ID_Sexo,
                            usuario.tipoSangre
                        );
                    }
                    //ViewBag.Message = "Usuario registrado";
                    TempData["Message"] = "Usuario Registrado";
                    Session["UserCorreo"] = usuario.correo.ToString();
                    Session["Nombre"] = usuario.nombre.ToString();
                    Session["ID_Usuario"] = usuario.cedula.ToString();
                    Session["ID_Sexo"] = usuario.ID_Sexo.ToString();
                    Session["Rol"] = "Cliente";
                    return RedirectToAction("Index", "DashboardU");
                }
                ////Validar excepción de SQL
                catch (Exception e)
                {
                    if (e.GetType().Name == "Exception")
                    {
                        ViewBag.Error = "El usuario ya existe, intente con otro número de cédula.";
                        DateTime dateTime = DateTime.Now;
                        using (var contextoUsuario = new ProyectoEntities())
                        {
                            contextoUsuario.InsertarErrores(
                               e.Message.ToString(), usuario.correo, dateTime
                            );
                        }
                    }
                    else
                    {
                        if (e.GetType().Name == "EntityCommandExecutionException")
                        {
                            ViewBag.Error = "El usuario ya existe, intente con otro número de cédula o correo electrónico.";
                            DateTime dateTime = DateTime.Now;
                            using (var contextoUsuario = new ProyectoEntities())
                            {
                                contextoUsuario.InsertarErrores(
                                   e.Message.ToString(), usuario.cedula, dateTime
                                );
                            }
                        }
                    }
                }
            }

            Index();
            return View();
        }


        public ActionResult RegistrarUsuario(string cedula)
        {
            RegistrarModel registrarModel = new RegistrarModel();
            var usuario = registrarModel.RegistrarUsuario(cedula);
            if (!string.IsNullOrEmpty(usuario.nombre))
            {
                return Json(usuario, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.DenyGet);
            }
        }

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

                ViewBag.ListaComboMotivo = listilla;
            }
        }

        public void CargarTipoSangre()
        {
            using (var contexto = new ProyectoEntities())
            {
                var respuesta = (from x in contexto.TipoSangre select x).ToList();
                List<SelectListItem> listilla = new List<SelectListItem>();

                foreach (var item in respuesta)
                {
                    listilla.Add(new SelectListItem { Value = item.ID_TipoSangre.ToString(), Text = item.Descripcion });
                }

                ViewBag.ListaComboSangre = listilla;
            }
        }

        public void CargarSexo()
        {
            using (var contexto = new ProyectoEntities())
            {
                var respuesta = (from x in contexto.Sexo select x).ToList();
                List<SelectListItem> listilla = new List<SelectListItem>();

                foreach (var item in respuesta)
                {
                    listilla.Add(new SelectListItem { Value = item.ID_Sexo.ToString(), Text = item.Sexo1 });
                }

                ViewBag.ListaComboSexo = listilla;
            }
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