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
    class SkillServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoSkillsReturnsEmptyCollection()
        {
            //Arrange
            var mockSkillRepository = GetDefaultISkillRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var skillId = 200;
            mockSkillRepository.Setup(r => r.FindById(skillId))
                .Returns(Task.FromResult<Skill>(null));

            var service = new SkillService(mockSkillRepository.Object, mockUnitOfWork.Object);
            //Act
            SkillResponse result = await service.GetByIdAsync(skillId);
            var message = result.Message;

            //Assert
            message.Should().Be("Skill not found");
        }

        private Mock<ISkillRepository> GetDefaultISkillRepositoryInstance()
        {
            return new Mock<ISkillRepository>();
        }


        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
