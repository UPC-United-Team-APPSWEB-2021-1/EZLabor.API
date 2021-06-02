using NUnit.Framework;
using Moq;
using FluentAssertions;
using System.Threading.Tasks;
using System.Collections.Generic;
using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.SocialMedia.Services;
using EZLabor.API.SocialMedia.Domain.Services.Communications;
using EZLabor.API.SocialMedia.Domain.Persistence.Respositories;
using EZLabor.API.Domain.Persistence.Repositories;

namespace EZLabor.API.Test
{
    public class NotificationServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoNotificationsReturnsEmptyCollection()
        {
            //Arrange
            var mockNotificationRepository = GetDefaultINotificationRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var notificationId = 200;
            mockNotificationRepository.Setup(r => r.FindById(notificationId))
                .Returns(Task.FromResult<Notification>(null));

            var service = new NotificationService(mockNotificationRepository.Object, mockUnitOfWork.Object);
            //Act
            NotificationResponse result = await service.GetByIdAsync(notificationId);
            var message = result.Message;

            //Assert
            message.Should().Be("Notification not found");
        }

        private Mock<INotificationRepository> GetDefaultINotificationRepositoryInstance()
        {
            return new Mock<INotificationRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}