using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Persistence.Repositories
{
    public interface IEmployerRepository
    {
        Task<IEnumerable<Employer>> ListAsync();
        Task AddAsync(Employer employer);
        Task<Employer> FindById(int id);
        void Update(Employer employer);
        void Remove(Employer employer);
    }
}
