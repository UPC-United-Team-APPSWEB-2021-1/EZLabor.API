using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Persistence.Repositories
{
    public interface IRequirementRepository
    {
        Task<IEnumerable<Requirement>> ListAsync();
        Task<IEnumerable<Requirement>> ListByOfferIdAsync(int offerId);
        Task AddAsync(Requirement requirement);
        Task<Requirement> FindById(int id);
        void Update(Requirement requirement);
        void Remove(Requirement requirement);

    }
}
