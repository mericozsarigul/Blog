using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Model.Rest;
using Blog.Model.Data;
using MimeKit;
using MailKit.Net.Smtp;

namespace Blog.WEB.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            EntryRestfulService service = new EntryRestfulService();
            List<Entry> data = await service.ListEntryAsync();

            return View(data);
        }

        public async Task<IActionResult> Detail(long id)
        {
            EntryRestfulService service = new EntryRestfulService();
            Entry data = await service.GetEntryAsync(id);
            return View(data);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
           ViewBag.Captcha = "6LcQUiIUAAAAAIYypyJefzVUM9MVmzq1buc7pV0G";
           return View();
        }

        public IActionResult SendEmail(Mail data)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Anuraj", "mericozsarigul@gmail.com"));
            message.To.Add(new MailboxAddress("Anuraj", "mericozsarigul@gmail.com"));
            message.Subject = "Hello World - A mail from ASPNET Core";
            message.Body = new TextPart("plain")
            {
                Text = "Hello World - A mail from ASPNET Core"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("mericozsarigul@gmail.com", "Ozlem@3541");
                client.Send(message);
                client.Disconnect(true);
            }
            return RedirectToAction("Contact");
        }

        

        public IActionResult Error()
        {
            return View();
        }
    }
}
