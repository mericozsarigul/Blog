using Blog.Model.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.Rest
{
    public class CategoryRestfulService
    {
        readonly string uri = "http://blog.api/api/category";

        public async Task<List<Category>> ListCategoryAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<Category>>(
                 await httpClient.GetStringAsync(uri)
             );
            }
        }

        public async Task<Category> GetCategoryAsync(long id)
        {
            string getUri = uri + "/" + id.ToString();

            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<Category>(await httpClient.GetStringAsync(getUri));
            }
        }

        public async Task PostCategory(Category data)
        {
            var jsonInString = JsonConvert.SerializeObject(data);

            using (HttpClient httpClient = new HttpClient())
            {
                await httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            }
        }

        public async Task UpdateCategory(Category data)
        {
            var jsonInString = JsonConvert.SerializeObject(data);

            using (HttpClient httpClient = new HttpClient())
            {
                await httpClient.PutAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
            }
        }

        public async Task DeleteCategory(long id)
        {
            string deleteUri = uri + "/" + id.ToString();

            using (HttpClient httpClient = new HttpClient())
            {
                await httpClient.DeleteAsync(deleteUri);
            }
        }
    }
}
