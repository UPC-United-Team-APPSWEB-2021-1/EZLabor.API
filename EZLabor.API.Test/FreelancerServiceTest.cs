using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.Services;
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
    class FreelancerServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoFreelancersReturnsEmptyCollection()
        {
            //Arrange
            var mockFreelancerRepository = GetDefaultIFreelancerRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var freelancerId = 200;
            mockFreelancerRepository.Setup(r => r.FindById(freelancerId))
                .Returns(Task.FromResult<Freelancer>(null));

            var service = new FreelancerService(mockFreelancerRepository.Object, mockUnitOfWork.Object);
            //Act
            FreelancerResponse result = await service.GetByIdAsync(freelancerId);
            var message = result.Message;

            //Assert
            message.Should().Be("Freelancer not found");
        }

        private Mock<IFreelancerRepository> GetDefaultIFreelancerRepositoryInstance()
        {
            return new Mock<IFreelancerRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
