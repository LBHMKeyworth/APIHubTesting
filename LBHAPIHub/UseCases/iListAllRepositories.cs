using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.APIHub.Data.Domain;

namespace LBHAPIHub.UseCases
{
    public interface IListAllRepositories
    {
        Task<List<Repository>> GetReposAsync();
    }
}
