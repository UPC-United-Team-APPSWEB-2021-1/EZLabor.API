using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.SocialMedia.Domain.Persistence.Respositories;
using EZLabor.API.SocialMedia.Domain.Services;
using EZLabor.API.SocialMedia.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Services
{
    public class NotificationService: INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<NotificationResponse> DeleteAsync(int id)
        {
            var existingNotification = await _notificationRepository.FindById(id);

            if (existingNotification == null)
                return new NotificationResponse("Notification not found");

            try
            {
                _notificationRepository.Remove(existingNotification);
                await _unitOfWork.CompleteAsync();

                return new NotificationResponse(existingNotification);
            }
            catch (Exception ex)
            {
                return new NotificationResponse($"An error ocurred while deleting the notification: {ex.Message}");
            }

        }

        public async Task<NotificationResponse> GetByIdAsync(int id)
        {
            var existingNotification = await _notificationRepository.FindById(id);

            if (existingNotification == null)
                return new NotificationResponse("Notification not found");
            return new NotificationResponse(existingNotification);
        }

        public async Task<IEnumerable<Notification>> ListAsync()
        {
            return await _notificationRepository.ListAsync();
        }

        public async Task<NotificationResponse> SaveAsync(Notification notification)
        {
            try
            {
                await _notificationRepository.AddAsync(notification);
                await _unitOfWork.CompleteAsync();

                return new NotificationResponse(notification);
            }
            catch (Exception ex)
            {
                return new NotificationResponse($"An error ocurred while saving the notification: {ex.Message}");
            }
        }

        public async Task<NotificationResponse> UpdateAsync(int id, Notification notification)
        {
            var existingNotification = await _notificationRepository.FindById(id);

            if (existingNotification == null)
                return new NotificationResponse("Notification not found");

            existingNotification.Description = notification.Description;

            try
            {
                _notificationRepository.Update(existingNotification);
                await _unitOfWork.CompleteAsync();

                return new NotificationResponse(existingNotification);
            }
            catch (Exception ex)
            {
                return new NotificationResponse($"An error ocurred while updating the notification: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Notification>> ListByFreelancerIdAsync(int freelancerId)
        {
            return await _notificationRepository.ListByFreelancerIdAsync(freelancerId);
        }
    }
}
