using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Persistence.Repositories
{
    public interface IMeetingRepository
    {
        Task<IEnumerable<Meeting>> ListAsync();
        Task<IEnumerable<Meeting>> ListByPostulationIdAsync(int postulationId);
        Task AddAsync(Meeting meeting);
        Task<Meeting> FindById(int id);
        void Update(Meeting meeting);
        void Remove(Meeting meeting);
    }
}
