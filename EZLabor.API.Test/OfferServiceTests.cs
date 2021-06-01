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
    class OfferServiceTests
    {

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public async Task GetAllAsyncWhenNoOffersReturnsEmptyCollection()
        {
            //Arrange
            var mockOfferRepository = GetDefaultIOfferRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var offerId = 200;
            mockOfferRepository.Setup(r => r.FindById(offerId))
                .Returns(Task.FromResult<Offer>(null));

            var service = new OfferService(mockOfferRepository.Object, mockUnitOfWork.Object);
            //Act
            OfferResponse result = await service.GetByIdAsync(offerId);
            var message = result.Message;

            //Assert
            message.Should().Be("Offer not found");
        }

        private Mock<IOfferRepository> GetDefaultIOfferRepositoryInstance()
        {
            return new Mock<IOfferRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }


    }
}
