using EZLabor.API.SocialMedia.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Persistence.Respositories
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task AddAsync(Publication publication);
        Task<Publication> FindById(int id);
        Task<IEnumerable<Publication>> ListByFreelancerIdAsync(int freelancerId);
        Task<IEnumerable<Publication>> ListByEmployerIdAsync(int employerId);
        void Update(Publication publication);
        void Remove(Publication publication);
    }
}
