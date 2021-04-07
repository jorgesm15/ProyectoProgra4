using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;


namespace ProyectoProgra4.Controllers
{
    public class PaginaPrincipalController : Controller
    {
        // GET: PaginaPrincipal
        [HttpGet]
        public ActionResult PaginaPrincipal()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        [HttpGet]
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string nombre, string apellidos, string telefono, string email, string mensaje)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("proyectoprogra4fidelitas@gmail.com", "Proyecto Gimnasio");
                    var receiverEmail = new MailAddress("proyectoprogra4fidelitas@gmail.com", "Proyecto Gimnasio");
                    var password = "";
                    var sub = "Solicitud de contacto de la Web";
                    var body = "Nombre: " + nombre + "\n\r" + "Apellidos: " + apellidos + "\n\r" + "Telefono: " + telefono + "\n\r" + "Email: " + email + "\n\r" + "Mensaje: " + mensaje;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = sub,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View("PaginaPrincipal");

                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }


    }


}
