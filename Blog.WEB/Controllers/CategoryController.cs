using Blog.Model.Data;
using Blog.Model.Rest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Blog.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private bool adminTempStatu = false;

        public IActionResult Add()
        {
            try
            {
                adminTempStatu = Convert.ToBoolean(HttpContext.Session.GetString("AdsminStatu"));

                if (adminTempStatu)
                {
                    return View();
                }
                else
                {
                    return Redirect("/Admin/Index");
                }
            }
            catch (Exception)
            {
                return Redirect("/Admin/Index");
            }
        }

        public async Task<IActionResult> Edit(long id)
        {
            try
            {
                adminTempStatu = Convert.ToBoolean(HttpContext.Session.GetString("AdminStatu"));

                if (adminTempStatu)
                {
                    CategoryRestfulService service = new CategoryRestfulService();
                    Category data = await service.GetCategoryAsync(id);

                    return View(data);
                }
                else
                {
                    return Redirect("/Admin/Index");
                }
            }
            catch (Exception)
            {
                return Redirect("/Admin/Index");
            }
        }

        public async Task<IActionResult> Save(Category data)
        {
            try
            {
                adminTempStatu = Convert.ToBoolean(HttpContext.Session.GetString("AdminStatu"));

                if (adminTempStatu)
                {
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            CategoryRestfulService serviceCategory = new CategoryRestfulService();
                            data.CreateDate = DateTime.Now;

                            await serviceCategory.PostCategory(data);
                            TempData["Result"] = "Entry başarıyla kaydedildi.";

                            return Redirect("/Admin/Category");
                        }
                        catch (Exception)
                        {
                            TempData["Result"] = "Entry kaydedilirken hata ile karşılaşıldı.";
                            return Redirect("/Admin/Category");
                        }
                    }
                    else
                    {
                        TempData["Result"] = "Gönderilen veri modeli istenilen şekilde değil.";
                        return Redirect("/Admin/Category");
                    }
                }
                else
                {
                    return Redirect("/Admin/Index");
                }
            }
            catch (Exception)
            {
                return Redirect("/Admin/Index");
            }
        }

        public async Task<IActionResult> Update(Category data)
        {
            try
            {
                adminTempStatu = Convert.ToBoolean(HttpContext.Session.GetString("AdminStatu"));

                if (adminTempStatu)
                {
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            CategoryRestfulService serviceCategory = new CategoryRestfulService();
                            data.CreateDate = DateTime.Now;

                            await serviceCategory.UpdateCategory(data);
                            TempData["Result"] = "Kategori başarıyla güncellendi.";

                            return Redirect("/Admin/Category");
                        }
                        catch (Exception)
                        {
                            TempData["Result"] = "Kategori güncellenirken hata ile karşılaşıldı.";
                            return Redirect("/Admin/Category");
                        }
                    }
                    else
                    {
                        TempData["Result"] = "Gönderilen veri modeli istenilen şekilde değil.";
                        return Redirect("/Admin/Category");
                    }
                }
                else
                {
                    return Redirect("/Admin/Index");
                }
            }
            catch (Exception)
            {
                return Redirect("/Admin/Index");
            }
        }

        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                adminTempStatu = Convert.ToBoolean(HttpContext.Session.GetString("AdminStatu"));

                if (adminTempStatu)
                {
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            CategoryRestfulService serviceCategory = new CategoryRestfulService();

                            await serviceCategory.DeleteCategory(id);
                            TempData["Result"] = "Kategori başarıyla silindi.";

                            return Redirect("/Admin/Category");
                        }
                        catch (Exception)
                        {
                            TempData["Result"] = "Kategori silinirken hatayla karşılaşıldı.";
                            return Redirect("/Admin/Category");
                        }
                    }
                    else
                    {
                        TempData["Result"] = "Silinecek kaydın Id bilgisi gönderilmelidir.";
                        return Redirect("/Admin/Category");
                    }
                }
                else
                {
                    return Redirect("/Admin/Index");
                }
            }
            catch (Exception)
            {
                return Redirect("/Admin/Index");
            }
        }
    }
}