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
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Instructor()
        {
            CargarEspecialidad();
            return View("InsertarInstructor");
        }


        public ActionResult InsertarInstructor(clsInstructor instructor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var contextoUsuario = new ProyectoEntities())
                    {
                        var rol = "Instructor";
                        var ID_Admin = Convert.ToInt32(Session["ID_Admin"]);
                        contextoUsuario.InsertarInstructores(
                            instructor.cedula, instructor.nombre, instructor.primerApellido, instructor.segundoApellido,
                            instructor.correo, instructor.edad, instructor.contrasenia, instructor.direccion, instructor.telefono,
                            instructor.telefonoEmergencia, instructor.condicionesMedicas, instructor.especialidad, ID_Admin, rol
                        );
                    }
                    ViewBag.Message = "Instructor registrado";
                    return View("InsertarInstructor");
                }
                catch (Exception e)
                {
                    if (e.GetType().Name == "Exception")
                    {
                        ViewBag.Error = "El instructor ya existe, intente con otro número de cédula.";
                        DateTime dateTime = DateTime.Now;
                        using (var contextoUsuario = new ProyectoEntities())
                        {
                            contextoUsuario.InsertarErrores(
                               e.Message.ToString(), instructor.correo, dateTime
                            );
                        }
                    }
                    else
                    {
                        if (e.GetType().Name == "EntityCommandExecutionException")
                        {
                            ViewBag.Error = "El usuario ya existe, intente con otro número de cédula.";
                            DateTime dateTime = DateTime.Now;
                            using (var contextoUsuario = new ProyectoEntities())
                            {
                                contextoUsuario.InsertarErrores(
                                   e.Message.ToString(), instructor.cedula, dateTime
                                );
                            }
                        }
                    }
                }
            }

            Instructor();
            ModelState.Clear();
            return View();
        }


        public void CargarEspecialidad()
        {
            using (var contexto = new ProyectoEntities())
            {
                var respuesta = (from x in contexto.Disciplinas select x).ToList();
                List<SelectListItem> listilla = new List<SelectListItem>();

                foreach (var item in respuesta)
                {
                    listilla.Add(new SelectListItem { Value = item.claseID.ToString(), Text = item.nombre});
                }

                ViewBag.ListaComboEspecialidad = listilla;
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