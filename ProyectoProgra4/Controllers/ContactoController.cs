using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgra4.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto
        public ActionResult Contacto()
        {
            return View();
        }

        public ActionResult SendEmail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("proyectoprogra4fidelitas@gmail.com", "Proyecto Gimnasio");
                    var receiverEmail = new MailAddress("proyectoprogra4fidelitas@gmail.com", "Proyecto Gimnasio");
                    var password = "A723r88pT57qh@f34tGh344%gd37";
                    var sub = subject;
                    var body = "Correo: " + receiver + "\n\r" + "Mensaje: " + message;
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
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
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