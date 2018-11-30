using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.APIHub.Data.Domain;

namespace LBHAPIHub.Gateways
{
    public interface IGitHubGateway
    {
        Task<List<Repository>> GetRepositoriesByOwner();
    }
}
