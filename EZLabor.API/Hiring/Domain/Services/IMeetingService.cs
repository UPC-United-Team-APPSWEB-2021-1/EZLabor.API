using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Services
{
    public interface IMeetingService
    {
        Task<IEnumerable<Meeting>> ListAsync();
        Task<IEnumerable<Meeting>> ListByPostulationIdAsync(int postulationId);
        Task<MeetingResponse> GetByIdAsync(int id);
        Task<MeetingResponse> SaveAsync(Meeting meeting);
        Task<MeetingResponse> UpdateAsync(int id, Meeting meeting);
        Task<MeetingResponse> DeleteAsync(int id);

    }
}
