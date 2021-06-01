using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Persistence.Repositories
{
    public interface IOfferRepository
    {
        Task<IEnumerable<Offer>> ListAsync();
        Task<IEnumerable<Offer>> ListByEmployerIdAsync(int employerId);
        Task AddAsync(Offer offer);
        Task<Offer> FindById(int id);
        void Update(Offer offer);
        void Remove(Offer offer);

    }
}
