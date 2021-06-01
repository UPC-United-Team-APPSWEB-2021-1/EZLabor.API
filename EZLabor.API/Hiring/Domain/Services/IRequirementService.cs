using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Services
{
    public interface IRequirementService
    {
        Task<IEnumerable<Requirement>> ListAsync();
        Task<IEnumerable<Requirement>> ListByOfferId(int offerId);
        Task<RequirementResponse> GetByIdAsync(int id);
        Task<RequirementResponse> SaveAsync(Requirement requirement);
        Task<RequirementResponse> UpdateAsync(int id, Requirement requirement);
        Task<RequirementResponse> DeleteAsync(int id);

    }
}
