using ProyectoProgra4.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoProgra4.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Clientes()
        {
            using (var contexto = new ProyectoEntities())
            {
                var clientes = (from x in contexto.Clientes.AsEnumerable()
                                select new Clientes()
                                    {
                                        ID_Cliente = x.ID_Cliente,
                                        Nombre = x.Nombre,
                                        PrimerApellido = x.PrimerApellido,
                                        SegundoApellido = x.SegundoApellido,
                                        Correo = x.Correo,
                                        Edad = x.Edad,
                                        Telefono = x.Telefono,
                                        TelefonoEmergencia = x.TelefonoEmergencia,
                                        Peso = x.Peso,
                                        Estatura = x.Estatura,
                                        CondicionesMedicas = x.CondicionesMedicas,
                                    }).ToList();

                Session["VerClientes"] = clientes;


                return View();
            }
        }

        
        


        public ActionResult ActualizarDatos(string clienteId) //Cargar Datos en la parte de mostrar vista reserva
        {
            using (var contexto = new ProyectoEntities())
            {

                var clientes = (from x in contexto.Clientes
                                    where x.ID_Cliente == clienteId
                                select x).FirstOrDefault();

                Dictionary<String, String> actualizacliente = new Dictionary<string, string>();


                actualizacliente.Add("ID_Cliente", clientes.ID_Cliente);
                actualizacliente.Add("Nombre", clientes.Nombre);
                actualizacliente.Add("PrimerApellido", clientes.PrimerApellido);
                actualizacliente.Add("SegundoApellido", clientes.SegundoApellido);
                actualizacliente.Add("Correo", clientes.Correo);
                actualizacliente.Add("Edad", clientes.Edad.ToString());
                actualizacliente.Add("Telefono", clientes.Telefono);
                actualizacliente.Add("TelefonoEmergencia", clientes.TelefonoEmergencia);
                actualizacliente.Add("Peso", clientes.Peso.ToString());
                actualizacliente.Add("Estatura", clientes.Estatura.ToString());
                actualizacliente.Add("CondicionesMedicas", clientes.CondicionesMedicas);

                if (clientes.ID_Cliente != clienteId)
                {
                    return Json(null, JsonRequestBehavior.DenyGet);
                }
                else
                {
                    return Json(actualizacliente, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult ActualizarCliente(clsUsuario cliente)
        {
            using (var contexto = new ProyectoEntities())
            {
                var ID_Administrador = Convert.ToInt32(Session["ID_Admin"]);
                var respuesta = (from x in contexto.Clientes
                                 where x.ID_Cliente == cliente.cedula
                                 select x).FirstOrDefault();
                if (respuesta != null)
                {
                    respuesta.ID_Cliente = cliente.cedula;
                    respuesta.Nombre = cliente.nombre;
                    respuesta.PrimerApellido = cliente.primerApellido;
                    respuesta.SegundoApellido = cliente.segundoApellido;
                    respuesta.Correo = cliente.correo;
                    respuesta.Edad = cliente.edad;
                    respuesta.Telefono = cliente.telefono;
                    respuesta.TelefonoEmergencia = cliente.telefonoEmergencia;
                    respuesta.Peso = cliente.peso;                    
                    respuesta.Estatura = cliente.estatura;
                    respuesta.CondicionesMedicas = cliente.condicionesMedicas;
                    contexto.SaveChanges();
                }
            }
            return RedirectToAction("Clientes");
        }

        public ActionResult EliminarCliente(string clienteId)
        {
            using (var contexto = new ProyectoEntities())
            {
                var clienteBuscado = (from x in contexto.Clientes
                                    where x.ID_Cliente == clienteId
                                    select x).FirstOrDefault();

                if (clienteBuscado != null)
                {
                    contexto.Clientes.Remove(clienteBuscado);
                    contexto.SaveChanges();
                    return RedirectToAction("Clientes");
                }
            }
            return View("Clientes");
        }
    }

}

