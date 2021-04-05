using ProyectoProgra4.Entidades;
using ProyectoProgra4.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace ProyectoProgra4.Controllers
{
    public class RegistrarController : Controller
    {
        // GET: Registrar
        public ActionResult Index()
        {
            CargarMotivo();
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
                        contextoUsuario.InsertarClientes(
                            usuario.cedula, usuario.nombre, usuario.primerApellido, usuario.segundoApellido,
                            usuario.correo, usuario.edad, GetMD5(usuario.contrasenia), usuario.direccion, usuario.telefono,
                            usuario.telefonoEmergencia, usuario.peso, usuario.estatura, usuario.condicionesMedicas, usuario.tipoSangre,
                            usuario.motivo
                        );
                    }
                    //ViewBag.Message = "Usuario registrado";
                    TempData["Message"] = "Usuario Registrado";
                    return RedirectToAction("PaginaPrincipal", "PaginaPrincipal");
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Dato duplicado";
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

        public void CargarMotivo()
        {
            using (var contexto = new ProyectoEntities())
            {
                var respuesta = (from x in contexto.Motivo select x).ToList();
                List<SelectListItem> listilla = new List<SelectListItem>();

                foreach (var item in respuesta)
                {
                    listilla.Add(new SelectListItem { Value = item.ID_Motivo.ToString(), Text = item.Descripcion });
                }

                ViewBag.ListaComboMotivo = listilla;
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