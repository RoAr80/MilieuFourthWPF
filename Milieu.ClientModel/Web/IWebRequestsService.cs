using System.Net.Http;
using System.Threading.Tasks;

namespace Milieu.ClientModels.Web
{
    public interface IWebRequestsService
    {
        Task<HttpResponseMessage> PostJsonAsync(string url,
            object content = null,
            string bearerToken = null);

        Task<HttpResponseMessage> GetAsyncJson(string url,
            string bearerToken = null);
    }
}
