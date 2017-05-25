using Blog.Model.Data;
using Blog.Model.Rest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
  
            var clearHtmlTags = Regex.Replace(data.Content, "<.*?>", String.Empty);
            data.Summary = clearHtmlTags.Length > 50 ? clearHtmlTags.Substring(0, 50) : clearHtmlTags;
           
            data.CreateDate = DateTime.Now;
              
            await serviceEntry.PostEntry(data);
 

            return Redirect("/Admin/Entry");
        }

        public async Task<IActionResult> Update(Entry data)
        {
            data.CreateDate = DateTime.Now;
            var clearHtmlTags = Regex.Replace(data.Content, "<.*?>", String.Empty);

            data.Summary = clearHtmlTags.Length > 50 ? clearHtmlTags.Substring(0, 50) : clearHtmlTags;

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