using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBHAPIHub.Settings;

namespace LBHAPIHub.Factory
{
    public class GitHubClientFactory : IGitHubClientFactory
    {
        private IHttpClient _client;
        private readonly GitHubSettings _configuration;

        public GitHubClientFactory(GitHubSettings appSettings)
        {
            _configuration = appSettings;
        }

        public async Task<IHttpClient> CreateClientAsync()
        {

            _client = new RestfulHttpClient();

            _client.SetBaseUrl(_configuration.GitHubUrl);
            _client.AddDefaultHeader("Accept", "application/json");
            _client.AddDefaultHeader("User-Agent", "LBHMKeyworth");
            
            return _client;
        }
    }
}
