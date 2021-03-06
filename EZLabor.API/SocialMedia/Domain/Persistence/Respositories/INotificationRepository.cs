using EZLabor.API.SocialMedia.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Persistence.Respositories
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> ListAsync();
        Task AddAsync(Notification notification);
        Task<Notification> FindById(int id);
        Task<IEnumerable<Notification>> ListByEmployerIdAsync(int employerId);
        Task<IEnumerable<Notification>> ListByFreelancerIdAsync(int FreelancerId);
        void Update(Notification notification);
        void Remove(Notification notification);
    }
}
