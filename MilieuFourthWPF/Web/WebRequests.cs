using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Milieu.Models.Responses;

namespace MilieuFourthWPF
{
    public static class WebRequests
    {
        
        public static async Task<HttpResponseMessage> PostJsonAsync(
            string url, 
            object content = null,             
            string bearerToken = null)
        {
            

            HttpClient client = DI.ServiceProvider.GetService<HttpClient>();            

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            if (bearerToken != null)
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

            var json = JsonConvert.SerializeObject(content);

            var data = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, data);

            return response;
        }


        public static async Task<HttpResponseMessage> GetAsyncJson(
            string url,            
            string bearerToken = null)
        {

            HttpClient client = DI.ServiceProvider.GetService<HttpClient>();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            if(bearerToken != null)
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);            
                        
            var response = await client.GetAsync(url);            

            return response;
        }
    }
}
