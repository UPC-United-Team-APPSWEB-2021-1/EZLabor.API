using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Persistence.Repositories
{
    public interface ISolutionRepository
    {
        Task<IEnumerable<Solution>> ListAsync();
        Task AddAsync(Solution solution);
        Task<Solution> FindById(int id);
        void Update(Solution solution);
        void Remove(Solution solution);
    }
}

