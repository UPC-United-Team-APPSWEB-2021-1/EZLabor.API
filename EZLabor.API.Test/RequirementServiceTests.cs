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
    class RequirementServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoRequirementsReturnsEmptyCollection()
        {
            //Arrange
            var mockRequirementRepository = GetDefaultIRequirementRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var requirementId = 200;
            mockRequirementRepository.Setup(r => r.FindById(requirementId))
                .Returns(Task.FromResult<Requirement>(null));

            var service = new RequirementService(mockRequirementRepository.Object, mockUnitOfWork.Object);
            //Act
            RequirementResponse result = await service.GetByIdAsync(requirementId);
            var message = result.Message;

            //Assert
            message.Should().Be("Requirement not found");
        }

        private Mock<IRequirementRepository> GetDefaultIRequirementRepositoryInstance()
        {
            return new Mock<IRequirementRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
