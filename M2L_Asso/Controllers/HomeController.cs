using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mail;

using M2L_Asso.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace M2L_Asso.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(Email model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new System.Net.Mail.MailMessage();
                message.To.Add(new MailAddress("ganesh.radje@ynov.com"));  // replace with valid value 
                message.From = new MailAddress("radjeganesh@hotmail.fr");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "ganesh.radje@outlook.fr",  // replace with valid value
                        Password = ""  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }

        public ActionResult Valres()
        {
            return View();
        }

        public ActionResult Fredi()
        {
            return View();
        }
    }
}