using Blog.Model.Data;
using Blog.Model.Rest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.WEB.Controllers
{
    public class EntryController : Controller
    {
        public async Task<IActionResult> Add()
        {
            CategoryRestfulService service = new CategoryRestfulService();
            List<Category> CategoryList = await service.ListCategoryAsync();

            ViewBag.Categories = CategoryList;
            return View();
        }

        public async Task<IActionResult> Edit(long id)
        {
            EntryRestfulService service = new EntryRestfulService();
            Entry data = await service.GetEntryAsync(id);
            return View(data);
        }

        public async Task<IActionResult> Save(Entry data, long Category)
        {
            EntryRestfulService serviceEntry = new EntryRestfulService();
            CategoryRestfulService serviceCategory = new CategoryRestfulService();
            var kategori = serviceCategory.GetCategoryAsync(Category);

            data.CreateDate = DateTime.Now;
            data.Summary = data.Content.Length > 50 ? data.Content.Substring(0, 50) : data.Content;
            data.Category = kategori.Result;


            
            await serviceEntry.PostEntry(data);

            return Redirect("/Admin/Entry");
        }

        public async Task<IActionResult> Update(Entry data)
        {
            data.CreateDate = DateTime.Now;
            data.Summary = data.Content.Length > 50 ? data.Content.Substring(0, 50) : data.Content;

            EntryRestfulService service = new EntryRestfulService();
            await service.UpdateEntry(data);

            return Redirect("/Admin/Entry");
        }

        public async Task<IActionResult> Delete(long id)
        {
            EntryRestfulService service = new EntryRestfulService();
            await service.DeleteEntry(id);
            return Redirect("/Admin/Entry");
        }
    }
}