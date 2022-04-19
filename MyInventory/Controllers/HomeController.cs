using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LifeLine.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace LifeLine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Aboutus()
        {
            return View();
        }
        public IActionResult ContactForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact record)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress("lifelinebots1@gmail.com", "The Administrator")
            };
            mail.To.Add(new MailAddress(record.Email));

            mail.Subject = "Inquiry from" + record.Email + " (" + record.FullName + ")";
            string message = "Hello, " + record.FullName + "<br/><br/>" +
                "We have received your inquiry. Here are the details" + "<br/><br/>" +
                "Message:<br>" + record.Message + "<br/><br/>" +
                "Please wait for our reply. Thank you.";
            mail.Body = message;
            mail.IsBodyHtml = true;

            using SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("lifelinebots1@gmail.com", "life_linebots123"),
                EnableSsl = true
            };
            smtp.Send(mail);
            ViewBag.Message = "Inquiry sent.";
            return RedirectToAction("Index");
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
