using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Model.Rest;
using Blog.Model.Data;
using MimeKit;
using MailKit.Net.Smtp;
using System.Net;

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

        public async Task<IActionResult> SendEmail(Mail data)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(data.Email));
            emailMessage.To.Add(new MailboxAddress("mericozsarigul@gmail.com"));
            emailMessage.Subject = "Blog İletişim";
            var builder = new BodyBuilder { TextBody = data.Message };

            emailMessage.Body = builder.ToMessageBody();
            using (var client = new SmtpClient())
            {
     
                await client.ConnectAsync("smtp.gmail.com", 587).ConfigureAwait(false);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }

            return RedirectToAction("Contact");
        }



        public IActionResult Error()
        {
            return View();
        }
    }
}
