using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Services
{
    public interface ISolutionService
    {
        Task<IEnumerable<Solution>> ListAsync();
        Task<SolutionResponse> GetByIdAsync(int id);
        Task<SolutionResponse> SaveAsync(Solution solution);
        Task<SolutionResponse> UpdateAsync(int id, Solution solution);
        Task<SolutionResponse> DeleteAsync(int id);
    }
}
