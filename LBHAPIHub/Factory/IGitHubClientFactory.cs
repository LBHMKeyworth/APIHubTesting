using System.Threading.Tasks;
namespace LBHAPIHub.Factory
{
    public interface IGitHubClientFactory
    {
        Task<IHttpClient> CreateClientAsync();
    }
}