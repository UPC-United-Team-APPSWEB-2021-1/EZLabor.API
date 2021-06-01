using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Persistence.Repositories
{
    public interface IPostulationRepository
    {
        Task<IEnumerable<Postulation>> ListAsync();
        Task<IEnumerable<Postulation>> ListByOfferIdAsync(int offerId);
        Task<IEnumerable<Postulation>> ListByFreelancerIdAsync(int freelancerId);
        Task AddAsync(Postulation postulation);
        Task<Postulation> FindById(int id);
        void Update(Postulation postulation);
        void Remove(Postulation postulation);
    }
}
