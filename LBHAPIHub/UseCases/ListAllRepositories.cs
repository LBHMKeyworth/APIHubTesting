using LBH.APIHub.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LBHAPIHub.Gateways;

namespace LBHAPIHub.UseCases
{
    public class ListAllRepositories : IListAllRepositories
    {
        private readonly IGitHubGateway gitHubGateway;
        public ListAllRepositories(IGitHubGateway gateway)
        {
            gitHubGateway = gateway;
        }

        public async Task<List<Repository>> GetReposAsync()
        {
            List<Repository> repos = new List<Repository>();

            repos = await gitHubGateway.GetRepositoriesByOwner();

            //HttpResponseMessage response = await client.GetAsync($"users/{repoOwner}/repos");
            //response.EnsureSuccessStatusCode();
            //if (response.IsSuccessStatusCode)
            //{
            //    repos = await response.Content.ReadAsAsync<List<Repository>>();
            //}
            // return URI of the created resource.
            return repos;
        }
    }
}
