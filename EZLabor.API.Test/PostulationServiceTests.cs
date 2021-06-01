using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Persistence.Repositories;
using EZLabor.API.Hiring.Domain.Services.Communications;
using EZLabor.API.Hiring.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZLabor.API.Test
{
    class PostulationServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoEmployersReturnsEmptyCollection()
        {
            //Arrange
            var mockPostulationRepository = GetDefaultIPostulationRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var postulationId = 200;
            mockPostulationRepository.Setup(r => r.FindById(postulationId))
                .Returns(Task.FromResult<Postulation>(null));

            var service = new PostulationService(mockPostulationRepository.Object, mockUnitOfWork.Object);
            //Act
            PostulationResponse result = await service.GetByIdAsync(postulationId);
            var message = result.Message;

            //Assert
            message.Should().Be("Postulation not found");
        }

        private Mock<IPostulationRepository> GetDefaultIPostulationRepositoryInstance()
        {
            return new Mock<IPostulationRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

    }
}
