using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace StokYonetimMobile.Models
{
    public class WebApiClient<T> where T : class, new()
    {
        public string BaseUrl { get; } = @"https://northwind.vercel.app/";

        public HttpClient Client { get; }

        public WebApiClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<T> Get(string url)
        {

            HttpResponseMessage response = await Client.GetAsync(url);
            var resultstring = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(resultstring);

            return result;

        }
        public async Task<List<T>> GetAll(string url)
        {

            HttpResponseMessage response = await Client.GetAsync(url);
            var resultstring = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<T>>(resultstring);

            return result;

        }
        public async Task<bool> Post(string url, T model)
        {

            var serilizeObject = System.Text.Json.JsonSerializer.Serialize(model);
            var stringContext = new StringContent(serilizeObject, Encoding.UTF8, "application/json");

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await Client.PostAsync(url, stringContext);
            //var resultstring = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;


        }
    }
}
