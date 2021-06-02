using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.SocialMedia.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> ListAsync();
        Task<IEnumerable<Notification>> ListByUserId(int userId);
        Task<NotificationResponse> GetByIdAsync(int id);
        Task<NotificationResponse> SaveAsync(Notification notification);
        Task<NotificationResponse> UpdateAsync(int id, Notification notification);
        Task<NotificationResponse> DeleteAsync(int id);
    }
}
