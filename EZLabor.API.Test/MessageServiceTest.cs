using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.Messaging.Domain.Model;
using EZLabor.API.Messaging.Domain.Persistence.Repositories;
using EZLabor.API.Messaging.Domain.Services.Communications;
using EZLabor.API.Messaging.Services;
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
    class MessageServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAndFreelancerIdAndEmployerIdAsyncWhenNoMessageFoundReturnsMessageNotFoundResponse()
        {
            //Arrange
            var mockMessageRepository = GetDefaultIMessageRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var messageId = 200;
            var freelancerId = 200;
            var employerId = 200;
            mockMessageRepository.Setup(r => r.FindByIdAndFreelancerIdAndEmployerId(messageId, freelancerId, employerId))
                .Returns(Task.FromResult<Message>(null));
            var service = new MessageService(mockMessageRepository.Object, mockUnitOfWork.Object);

            //Act
            MessageResponse result = await service.GetByIdAndFreelancerIdAndEmployerIdAsync(messageId, freelancerId, employerId);
            var message = result.Message;

            //Assert
            message.Should().Be("Message not found");
        }
        private Mock<IMessageRepository> GetDefaultIMessageRepositoryInstance()
        {
            return new Mock<IMessageRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }


    }
}
