using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Services
{
    public interface IOfferService
    {
        Task<IEnumerable<Offer>> ListAsync();
        Task<IEnumerable<Offer>> ListByEmployerId(int employerId);
        Task<OfferResponse> GetByIdAsync(int id);
        Task<OfferResponse> SaveAsync(Offer offer);
        Task<OfferResponse> UpdateAsync(int id, Offer offer);
        Task<OfferResponse> DeleteAsync(int id);
    }
}
