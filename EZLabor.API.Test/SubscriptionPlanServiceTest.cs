using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Subscription.Domain.Model;
using EZLabor.API.Subscription.Domain.Persistence.Repositories;
using EZLabor.API.Subscription.Domain.Services.Communications;
using EZLabor.API.Subscription.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;

namespace EZLabor.API.Test
{
    class SubscriptionPlanServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetByIdAsyncWhenNoSubscriptionPlanFoundReturnsSubscriptionPlanNotFoundResponse()
        {
            //Arrange
            var mockSubscriptionPlanRepository = GetDefaultISubscriptionPlanRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var subscriptionPlanId = 200;
            mockSubscriptionPlanRepository.Setup(r => r.FindById(subscriptionPlanId))
                .Returns(Task.FromResult<SubscriptionPlan>(null));
            var service = new SubscriptionPlanService(mockSubscriptionPlanRepository.Object, mockUnitOfWork.Object);

            //Act
            SubscriptionPlanResponse result = await service.GetByIdAsync(subscriptionPlanId);
            var message = result.Message;

            //Assert
            message.Should().Be("Subscription Plan not found");
        }
        private Mock<ISubscriptionPlanRepository> GetDefaultISubscriptionPlanRepositoryInstance()
        {
            return new Mock<ISubscriptionPlanRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
