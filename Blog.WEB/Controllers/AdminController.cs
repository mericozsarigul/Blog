using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
            if(Username=="admin" && Password == "admin")
            {
                TempData["admin"] = true;
                return RedirectToAction("AddEntry");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddEntry()
        {
            var adminStatu = TempData["admin"];
            if(adminStatu!=null)
            {
                if (Convert.ToBoolean(adminStatu))
                {
                    return View();
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