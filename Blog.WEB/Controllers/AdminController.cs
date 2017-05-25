using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Blog.Model.Data;
using Blog.Model.Rest;

namespace Blog.WEB.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Index(string Username, string Password)
        {
            
            if (Username=="admin" && Password == "admin")
            {
                HttpContext.Session.SetString("AdminStatu", "true");
                return RedirectToAction("Entry");
            }
            return View();
        }


        public async Task<IActionResult> Entry()
        {
            var adminTempStatu = HttpContext.Session.GetString("AdminStatu");

            if (adminTempStatu != null)
            {
                if (Convert.ToBoolean(adminTempStatu))
                {
                    EntryRestfulService service = new EntryRestfulService();
                    List<Entry> data = await service.ListEntryAsync();

                    return View(data);
                }
                else
                {
                    return Redirect("Index");
                }
            }
            else
            {
                return Redirect("Index");
            }
        }
        public async Task<IActionResult> Category()
        {
            var adminTempStatu = HttpContext.Session.GetString("AdminStatu");

            if (adminTempStatu != null)
            {
                if (Convert.ToBoolean(adminTempStatu))
                {
                    CategoryRestfulService service = new CategoryRestfulService();
                    List<Category> data = await service.ListCategoryAsync();

                    return View(data);
                }
                else
                {
                    return Redirect("Index");
                }
            }
            else
            {
                return Redirect("Index");
            }
        }


    }
}