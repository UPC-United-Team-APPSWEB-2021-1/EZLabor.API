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
    public class PublicationServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoPublicationsReturnsEmptyCollection()
        {
            //Arrange
            var mockPublicationRepository = GetDefaultIPublicationRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var publicationId = 200;
            mockPublicationRepository.Setup(r => r.FindById(publicationId))
                .Returns(Task.FromResult<Publication>(null));

            var service = new PublicationService(mockPublicationRepository.Object, mockUnitOfWork.Object);
            //Act
            PublicationResponse result = await service.GetByIdAsync(publicationId);
            var message = result.Message;

            //Assert
            message.Should().Be("Publication not found");
        }

        private Mock<IPublicationRepository> GetDefaultIPublicationRepositoryInstance()
        {
            return new Mock<IPublicationRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}