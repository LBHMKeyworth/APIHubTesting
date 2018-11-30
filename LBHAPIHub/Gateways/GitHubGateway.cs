using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.APIHub.Data.Domain;
using LBHAPIHub.Factory;
using LBHAPIHub.Settings;
using Newtonsoft.Json;

namespace LBHAPIHub.Gateways
{
    public class GitHubGateway : IGitHubGateway
    {
        private readonly IGitHubClientFactory _gitHubClientFactory;
        private readonly GitHubSettings _configuration;
        public GitHubGateway(IGitHubClientFactory gitHubClientFactory, GitHubSettings gitHubSettings)
        {
            _gitHubClientFactory = gitHubClientFactory;
            _configuration = gitHubSettings;
        }

        public async Task<List<Repository>> GetRepositoriesByOwner()
        {

            var httpClient = await _gitHubClientFactory.CreateClientAsync().ConfigureAwait(false);
            List<Repository> repos = new List<Repository>();

            var response = await httpClient.GetAsync($"users/{_configuration.GitHubOwner}/repos").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!string.IsNullOrEmpty(json))
                {
                    repos = JsonConvert.DeserializeObject<List<Repository>>(json);
                }
            }
            // return URI of the created resource.
            return repos;
        }


    }
}
