using Blog.Model.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.Rest
{
    public class EntryRestfulService
    {
        readonly string uri = "http://blog.api/api/entry";

        public void PostEntry(Entry data)
        {
            Entry e = new Entry();
            e.Content = "cont";
            e.CreateDate = DateTime.Now;
            e.Title = "tit";

            var jsonInString = JsonConvert.SerializeObject(data);

            var client = new HttpClient();
            client.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
        }

        public async Task<List<Entry>> ListEntryAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<Entry>>(
                 await httpClient.GetStringAsync(uri)
             );
            }
        }
    }
}