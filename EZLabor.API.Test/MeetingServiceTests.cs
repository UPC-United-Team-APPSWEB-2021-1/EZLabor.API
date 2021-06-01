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
    class MeetingServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoMeetingsReturnsEmptyCollection()
        {
            //Arrange
            var mockMeetingRepository = GetDefaultIMeetingRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var meetingId = 200;
            mockMeetingRepository.Setup(r => r.FindById(meetingId))
                .Returns(Task.FromResult<Meeting>(null));

            var service = new MeetingService(mockMeetingRepository.Object, mockUnitOfWork.Object);
            //Act
            MeetingResponse result = await service.GetByIdAsync(meetingId);
            var message = result.Message;

            //Assert
            message.Should().Be("Meeting not found");
        }

        private Mock<IMeetingRepository> GetDefaultIMeetingRepositoryInstance()
        {
            return new Mock<IMeetingRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
