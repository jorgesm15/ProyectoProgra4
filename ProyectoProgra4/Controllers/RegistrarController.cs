using ProyectoProgra4.Entidades;
using ProyectoProgra4.Models;
using System;
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
            return View("InsertarUsuario");
        }

        //Prueba

        //public ActionResult InsertarUsuario(clsUsuario usuario)
        //{
        //    try
        //    {
        //        using (var contextoUsuario = new ProyectoEntities())
        //        {
        //            contextoUsuario.InsertarClientes(
        //                usuario.cedula, usuario.nombre, usuario.primerApellido, usuario.segundoApellido,
        //                usuario.correo, usuario.edad, GetMD5(usuario.contrasenia), usuario.direccion, usuario.telefono,
        //                usuario.telefonoEmergencia, usuario.peso, usuario.estatura, usuario.condicionesMedicas, usuario.tipoSangre
        //            );
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.Error = "Dato duplicado";
        //    }
        //    return View();
        //}

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