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

        // GET: api/values
        [HttpGet]
        public List<Category> Get()
        {
            List<Category> list = new List<Category>();
            list = repoCategory.GetAll().ToList();
            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Category Get(long id)
        {
            Category data = new Category();
            data = repoCategory.Get(id);
            return data;
        }

        // POST api/values
        [HttpPost]
        public void Post(Category entry)
        {
            repoCategory.Insert(entry);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Category entry)
        {
            repoCategory.Update(entry);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            Category data = new Category();
            data = repoCategory.Get(id);
            repoCategory.Delete(data);
        }
    }
}
