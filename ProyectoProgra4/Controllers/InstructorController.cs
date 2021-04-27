using ProyectoProgra4.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace ProyectoProgra4.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Instructor()
        {
            CargarEspecialidad();
            CargarSexo();
            CargarTipoSangre();
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
                            instructor.correo, instructor.edad, GetMD5(instructor.contrasenia), instructor.direccion, instructor.telefono,
                            instructor.telefonoEmergencia, instructor.condicionesMedicas, instructor.especialidad, ID_Admin, rol, instructor.sexo,
                            instructor.tipoSangre
                        );
                    }
                    TempData["MsjInstructor"] = "Instructor registrado";
                    //Session["InstructorRegistrado"] = "Registrado"; //Se crea esta sesión para que el instructor no pueda volver a la página anterior con los campos ya rellenos, lo devuelve al dashboard
                    CargarEspecialidad();
                    return RedirectToAction("Index", "AdministrarInstructor");
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
                            ViewBag.Error = "El usuario ya existe, intente con otro número de cédula";
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
                    listilla.Add(new SelectListItem { Value = item.claseID.ToString(), Text = item.nombre });
                }

                ViewBag.ListaComboEspecialidad = listilla;
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