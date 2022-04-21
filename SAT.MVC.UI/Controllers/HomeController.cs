using SAT.MVC.UI.Models;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace SAT.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            string msg = $"{cvm.Name} has sent you the following message:<br />" +
                $"Subject: <strong>{cvm.Subject}</strong><br />" +
                $"{cvm.Message}" +
                $"Please reply to {cvm.Email} at your earliest convenience.";


            MailMessage mm = new MailMessage(

                ConfigurationManager.AppSettings["EmailUser"].ToString(),
                ConfigurationManager.AppSettings["EmailTo"].ToString(),
                cvm.Subject,
                msg);

            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            mm.ReplyToList.Add(cvm.Email);

            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());

            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailUser"].ToString(), ConfigurationManager.AppSettings["EmailPass"].ToString());

            try
            {
                //Send email
                client.Send(mm);
            }
            catch (Exception ex)
            {
                //Log error in the ViewBag
                ViewBag.CustomerMessage = $"We're sorry. Your request could not be completed at this time." +
                    $"Please try again later! <br />" +
                    $"Error Message:<br />" +
                    $"{ex.StackTrace}";
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);
        }
    }
}
