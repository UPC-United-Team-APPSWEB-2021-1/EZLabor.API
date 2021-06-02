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
    public class QualificationServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoQualificationsReturnsEmptyCollection()
        {
            //Arrange
            var mockQualificationRepository = GetDefaultIQualificationRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var qualificationId = 200;
            mockQualificationRepository.Setup(r => r.FindById(qualificationId))
                .Returns(Task.FromResult<Qualification>(null));

            var service = new QualificationService(mockQualificationRepository.Object, mockUnitOfWork.Object);
            //Act
            QualificationResponse result = await service.GetByIdAsync(qualificationId);
            var message = result.Message;

            //Assert
            message.Should().Be("Qualification not found");
        }

        private Mock<IQualificationRepository> GetDefaultIQualificationRepositoryInstance()
        {
            return new Mock<IQualificationRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}