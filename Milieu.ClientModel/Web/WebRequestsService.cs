using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Milieu.ClientModels.Web
{
    public class WebRequestsService : IWebRequestsService
    {
        private HttpClient _client;

        public WebRequestsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> PostJsonAsync(
            string url, 
            object content = null,             
            string bearerToken = null)
        {

            // ToDo: заглушка, переделать
            //HttpClient _client = new HttpClient();   

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            if (bearerToken != null)
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

            var json = JsonConvert.SerializeObject(content);

            var data = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, data);

            return response;
        }


        public async Task<HttpResponseMessage> GetAsyncJson(
            string url,            
            string bearerToken = null)
        {
            // ToDo: заглушка, переделать
            //HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            if(bearerToken != null)
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);            
                        
            var response = await _client.GetAsync(url);            

            return response;
        }
    }
}
