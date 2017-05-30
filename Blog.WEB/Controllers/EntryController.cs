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
        bool adminTempStatu = false;

        public async Task<IActionResult> Add()
        {
            try
            {
                adminTempStatu = Convert.ToBoolean(HttpContext.Session.GetString("AdminStatu"));

                if (adminTempStatu)
                {
                    CategoryRestfulService service = new CategoryRestfulService();
                    List<Category> CategoryList = await service.ListCategoryAsync();

                    ViewBag.Categories = CategoryList;
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
                    EntryRestfulService service = new EntryRestfulService();
                    Entry data = await service.GetEntryAsync(id);

                    CategoryRestfulService categoryService = new CategoryRestfulService();
                    List<Category> CategoryList = await categoryService.ListCategoryAsync();

                    ViewBag.Categories = CategoryList;

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

        public async Task<IActionResult> Save(Entry data)
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
                            EntryRestfulService serviceEntry = new EntryRestfulService();
                            CategoryRestfulService serviceCategory = new CategoryRestfulService();

                            Category category = await serviceCategory.GetCategoryAsync(data.CategoryId);
                            var clearHtmlTags = Regex.Replace(data.Content, "<.*?>", String.Empty);

                            data.Summary = clearHtmlTags.Length > 200 ? clearHtmlTags.Substring(0, 200)+" ..." : clearHtmlTags;
                            data.CategoryName = category.Title;
                            data.CreateDate = DateTime.Now;

                            await serviceEntry.PostEntry(data);
                            TempData["Result"] = "Entry başarıyla kaydedildi.";

                            return Redirect("/Admin/Entry");
                        }
                        catch (Exception)
                        {
                            TempData["Result"] = "Entry kaydedilirken hata ile karşılaşıldı.";
                            return Redirect("/Admin/Entry");
                        }
                    }
                    else
                    {
                        TempData["Result"] = "Gönderilen veri modeli istenilen şekilde değil.";
                        return Redirect("/Admin/Entry");
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

        public async Task<IActionResult> Update(Entry data)
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
                            EntryRestfulService serviceEntry = new EntryRestfulService();
                            CategoryRestfulService serviceCategory = new CategoryRestfulService();

                            Category category = await serviceCategory.GetCategoryAsync(data.CategoryId);
                            var clearHtmlTags = Regex.Replace(data.Content, "<.*?>", String.Empty);

                            data.Summary = clearHtmlTags.Length > 50 ? clearHtmlTags.Substring(0, 50) : clearHtmlTags;
                            data.CategoryName = category.Title;
                            data.CreateDate = DateTime.Now;

                            await serviceEntry.UpdateEntry(data);
                            TempData["Result"] = "Entry başarıyla güncellendi.";

                            return Redirect("/Admin/Entry");
                        }
                        catch (Exception)
                        {
                            TempData["Result"] = "Entry güncellenirken hata ile karşılaşıldı.";
                            return Redirect("/Admin/Entry");
                        }

                    }
                    else
                    {
                        TempData["Result"] = "Gönderilen veri modeli istenilen şekilde değil.";
                        return Redirect("/Admin/Entry");
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
                            EntryRestfulService service = new EntryRestfulService();

                            await service.DeleteEntry(id);
                            TempData["Result"] = "Entry başarıyla silindi.";

                            return Redirect("/Admin/Entry");
                        }
                        catch (Exception)
                        {
                            TempData["Result"] = "Entry silinirken hatayla karşılaşıldı.";
                            throw;
                        }

                    }
                    else
                    {
                        TempData["Result"] = "Silinecek kaydın Id bilgisi gönderilmelidir.";
                        return Redirect("/Admin/Entry");
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