using EZLabor.API.Accounts.Domain.Services.Communications;
using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Services
{
    public interface IFreelancerService
    {
        Task<IEnumerable<Freelancer>> ListAsync();
        Task<IEnumerable<Freelancer>> ListByEmployerId(int employerId);
        Task<FreelancerResponse> GetByIdAsync(int id);
        Task<FreelancerResponse> SaveAsync(Freelancer freelancer);
        Task<FreelancerResponse> UpdateAsync(int id, Freelancer freelancer);
        Task<FreelancerResponse> DeleteAsync(int id);
        AuthenticationResponse Authenticate(AuthenticationRequest request);
        IEnumerable<Freelancer> GetAll();
    }
}
