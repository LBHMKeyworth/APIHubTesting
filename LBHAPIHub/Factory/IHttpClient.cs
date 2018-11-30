using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace LBHAPIHub.Factory
{
    public interface IHttpClient
    {
        void AddDefaultHeader(string key, string value);
        void SetBaseUrl(string baseUrl);
        Task<HttpResponseMessage> GetAsync(string url);
    }
}