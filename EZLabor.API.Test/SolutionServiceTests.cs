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
    class SolutionServiceTests
    {
        class PostulationServiceTests
        {
            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public async Task GetAllAsyncWhenNoSolutionsReturnsEmptyCollection()
            {
                //Arrange
                var mockSolutionRepository = GetDefaultISolutionRepositoryInstance();
                var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
                var solutionId = 200;
                mockSolutionRepository.Setup(r => r.FindById(solutionId))
                    .Returns(Task.FromResult<Solution>(null));

                var service = new SolutionService(mockSolutionRepository.Object, mockUnitOfWork.Object);
                //Act
                SolutionResponse result = await service.GetByIdAsync(solutionId);
                var message = result.Message;

                //Assert
                message.Should().Be("Solution not found");
            }

            private Mock<ISolutionRepository> GetDefaultISolutionRepositoryInstance()
            {
                return new Mock<ISolutionRepository>();
            }

            private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
            {
                return new Mock<IUnitOfWork>();
            }

        }
    }

}
