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

        public async Task<IActionResult> Edit(long id)
        {
            EntryRestfulService service = new EntryRestfulService();
            Entry data = await service.GetEntryAsync(id);
            return View(data);
        }

        public IActionResult Save(Entry data)
        {
            data.CreateDate = DateTime.Now;
            data.Summary = data.Content.Length > 50 ? data.Content.Substring(0, 50) : data.Content;

            EntryRestfulService service = new EntryRestfulService();
            service.PostEntry(data);

            return Redirect("/Admin/EntryAsync");
        }

        public IActionResult Update(Entry data)
        {
            data.CreateDate = DateTime.Now;
            data.Summary = data.Content.Length > 50 ? data.Content.Substring(0, 50) : data.Content;

            EntryRestfulService service = new EntryRestfulService();
            service.UpdateEntry(data);

            return Redirect("/Admin/EntryAsync");
        }

        public async Task<IActionResult> Delete(long id)
        {
            EntryRestfulService service = new EntryRestfulService();
            await service.DeleteEntryAsync(id);
            return Redirect("/Admin/EntryAsync");
        }
    }
}