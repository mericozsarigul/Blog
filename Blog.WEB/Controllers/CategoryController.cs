using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Model.Rest;
using Blog.Model.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.WEB.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Edit(long id)
        {
            CategoryRestfulService service = new CategoryRestfulService();
            Category data = await service.GetCategoryAsync(id);

            return View(data);
        }

        public async Task<IActionResult> Save(Category data)
        {
            CategoryRestfulService serviceCategory = new CategoryRestfulService();
            data.CreateDate = DateTime.Now;

            await serviceCategory.PostCategory(data);

            return Redirect("/Admin/Category");
        }

        public async Task<IActionResult> Update(Category data)
        {
            CategoryRestfulService serviceCategory = new CategoryRestfulService();

            data.CreateDate = DateTime.Now;

            await serviceCategory.UpdateCategory(data);

            return Redirect("/Admin/Category");
        }

        public async Task<IActionResult> Delete(long id)
        {
            CategoryRestfulService serviceCategory = new CategoryRestfulService();
            await serviceCategory.DeleteCategory(id);

            return Redirect("/Admin/Category");
        }
    }
}
