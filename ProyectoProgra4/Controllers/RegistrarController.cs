using ProyectoProgra4.Entidades;
using ProyectoProgra4.Models;
using System;
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

        public ActionResult InsertarUsuario(clsUsuario usuario)
        {
            try
            {
                using (var contextoUsuario = new ProyectoEntities1())
                {
                    contextoUsuario.InsertarClientes(
                        usuario.cedula, usuario.nombre, usuario.primerApellido, usuario.segundoApellido,
                        usuario.correo, usuario.edad, usuario.contrasenia, usuario.direccion, usuario.telefono,
                        usuario.telefonoEmergencia, usuario.peso, usuario.estatura, usuario.condicionesMedicas, usuario.tipoSangre
                    );
                }

            }
            catch (Exception e)
            {
                return Json(new { success = false, responseText = "Error al insertar", JsonRequestBehavior.AllowGet });
            }
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

    }
}