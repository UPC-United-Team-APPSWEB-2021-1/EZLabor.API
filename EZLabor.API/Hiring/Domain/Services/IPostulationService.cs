using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Services
{
    public interface IPostulationService
    {
        Task<IEnumerable<Postulation>> ListAsync();
        Task<IEnumerable<Postulation>> ListByFreelancerId(int freelancerId);
        Task<IEnumerable<Postulation>> ListByOfferId(int offerId);
        Task<PostulationResponse> GetByIdAsync(int id);
        Task<PostulationResponse> SaveAsync(Postulation postulation);
        Task<PostulationResponse> UpdateAsync(int id, Postulation skill);
        Task<PostulationResponse> DeleteAsync(int id);
    }
}
