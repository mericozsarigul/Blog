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

        // GET: api/values
        [HttpGet]
        public List<Entry> Get()
        {
            List<Entry> list = new List<Entry>();
            list = repoEntry.GetAll().ToList();
            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Entry Get(long id)
        {
            Entry data = new Entry();
            data = repoEntry.Get(id);
            return data;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Entry entry)
        {
            repoEntry.Insert(entry);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Entry entry)
        {
            repoEntry.Update(entry);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            Entry data = new Entry();
            data = repoEntry.Get(id);
            repoEntry.Delete(data);
        }
    }
}
