using NUnit.Framework;
using Moq;
using FluentAssertions;
using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EZLabor.API.Test
{
    public class EmployerServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoEmployersReturnsEmptyCollection()
        {
            //Arrange
            var mockEmployerRepository = GetDefaultIEmployerRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var employerId = 200;
            mockEmployerRepository.Setup(r => r.FindById(employerId))
                .Returns(Task.FromResult<Employer>(null));

            var service = new EmployerService(mockEmployerRepository.Object, mockUnitOfWork.Object);
            //Act
            EmployerResponse result = await service.GetByIdAsync(employerId);
            var message = result.Message;

            //Assert
            message.Should().Be("Employer not found");
        }

        private Mock<IEmployerRepository> GetDefaultIEmployerRepositoryInstance()
        {
            return new Mock<IEmployerRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}