using EZLabor.API.SocialMedia.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Persistence.Respositories
{
    public interface IQualificationRepository
    {
        Task<IEnumerable<Qualification>> ListAsync();
        Task AddAsync(Qualification qualification);
        Task<Qualification> FindById(int id);
        Task<IEnumerable<Qualification>> ListBySolutionIdAsync(int solutionId);
        void Update(Qualification qualification);
        void Remove(Qualification qualification);
    }
}
