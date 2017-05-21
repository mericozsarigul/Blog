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

        
        public async Task<List<Entry>> ListEntryAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<Entry>>(
                 await httpClient.GetStringAsync(uri)
             );
            }
        }

        public async Task<Entry> GetEntryAsync(long id)
        {
            string getUri = uri + "/" + id.ToString();

            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<Entry>(await httpClient.GetStringAsync(getUri));
            }
        }

        public async Task PostEntry(Entry data)
        {
            var jsonInString = JsonConvert.SerializeObject(data);

            using (HttpClient httpClient = new HttpClient())
            {
                await httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            }
        }

        public async Task UpdateEntry(Entry data)
        {
            var jsonInString = JsonConvert.SerializeObject(data);

            using (HttpClient httpClient = new HttpClient())
            {
               await httpClient.PutAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            }
        }

        public async Task DeleteEntry(long id)
        {
            string deleteUri = uri + "/" + id.ToString();

            using (HttpClient httpClient = new HttpClient())
            {
                await httpClient.DeleteAsync(deleteUri);
            }
        }
    }
}