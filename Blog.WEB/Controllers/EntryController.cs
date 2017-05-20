using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Model.Data;
 
using System.Net.Http;
using Blog.Model.Rest;

namespace Blog.WEB.Controllers
{
    public class EntryController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> SaveAsync(Entry data)
        {
            data.CreateDate = DateTime.Now;
            data.Summary = data.Content.Length > 50 ? data.Content.Substring(0, 50) : data.Content;

            EntryRestfulService service = new EntryRestfulService();
            service.PostEntry(data);

            return Redirect("/Admin/EntryAsync");
        }

        public IActionResult Update(Entry postData)
        {

            return View();
        }
    }
}