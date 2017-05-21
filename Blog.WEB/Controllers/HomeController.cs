using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Model.Rest;
using Blog.Model.Data;

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
            return RedirectToAction("Contact");
        }

        

        public IActionResult Error()
        {
            return View();
        }
    }
}
