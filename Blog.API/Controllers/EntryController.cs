using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.API.Models.Repository;
using Blog.Model.Data;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    public class EntryController : Controller
    {
        private IBlogRepository<Entry> repoEntry;

        public EntryController(IBlogRepository<Entry> repoEntry)
        {
            this.repoEntry = repoEntry;
        }


        [HttpGet]
        public List<Entry> Get()
        {
            try
            {
                List<Entry> list = new List<Entry>();
                list = repoEntry.GetAll().ToList();
                return list;
            }
            catch (Exception)
            {

                return null;
            }
           
        }


        [HttpGet("{id}")]
        public Entry Get(long id)
        {
            try
            {
                Entry data = new Entry();
                data = repoEntry.Get(id);
                return data;
            }
            catch (Exception)
            {

                return null;
            }
            
        }


        [HttpPost]
        public void Post([FromBody]Entry entry)
        {
            try
            {
                repoEntry.Insert(entry);
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        [HttpPut]
        public void Put([FromBody]Entry entry)
        {
            try
            {
                repoEntry.Update(entry);
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
                Entry data = new Entry();
                data = repoEntry.Get(id);
                repoEntry.Delete(data);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
