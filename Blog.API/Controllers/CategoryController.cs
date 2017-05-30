using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.API.Models.Repository;
using Blog.Model.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private IBlogRepository<Category> repoCategory;

        public CategoryController(IBlogRepository<Category> repoCategory)
        {
            this.repoCategory = repoCategory;
        }


        [HttpGet]
        public List<Category> Get()
        {
            try
            {
                List<Category> list = new List<Category>();
                list = repoCategory.GetAll().ToList();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

 
        [HttpGet("{id}")]
        public Category Get(long id)
        {
            try
            {
                Category data = new Category();
                data = repoCategory.Get(id);
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public void Post([FromBody]Category entry)
        {
            try
            {
                repoCategory.Insert(entry);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut("{id}")]
        public void Put([FromBody]Category entry)
        {
            try
            {
                repoCategory.Update(entry);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            try
            {
                Category data = new Category();
                data = repoCategory.Get(id);
                repoCategory.Delete(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
