using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Model.Rest;
using Blog.Model.Data;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Blog.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;
        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

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
            try
            {

                MimeMessage message = new MimeMessage();
                message.Subject = "Blog - "+ data.Name;
                message.Body = new TextPart("Html") { Text = data.Name+" <br/> "+ data.Email + "  <br/> " + data.Message };
                message.From.Add(new MailboxAddress(data.Email));
                message.To.Add(new MailboxAddress("mericozsarigul@gmail.com"));

                SmtpClient smtp = new SmtpClient();
                smtp.Connect(
                      "smtp.gmail.com"
                    , 587
                    , MailKit.Security.SecureSocketOptions.StartTls
                );
                smtp.Authenticate("mericozsarigul@gmail.com", "");
                smtp.Send(message);
                smtp.Disconnect(true);
                TempData["SendEmail"] = "Mesajınız başarıyla gönderildi";
            }
            catch (Exception)
            {
                TempData["SendEmail"] = "Mesaj gönderilirken hata ile karşılaşıldı.";
                return RedirectToAction("Contact");
            }
            return RedirectToAction("Contact");
        }

        

        public IActionResult Error()
        {
            return View();
        }

        public ActionResult TinyMceUpload(IFormFile files)
        {
            var location = Path.Combine(_environment.WebRootPath, "uploads");
            
                if (files.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(location, files.FileName), FileMode.Create))
                    {
                    files.CopyTo(fileStream);
                    }
                }
            location = @"..\..\uploads\" + files.FileName;
            return Json(new { location });
        }
    }
}
