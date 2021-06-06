using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Persistence.Repositories;
using EZLabor.API.Hiring.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace EZLabor.API.Specs.Features
{
    [Binding]
    public class VisualizeOffersSteps
    {
        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
        private static Mock<IOfferRepository> GetDefaultOfferRepositoryInstance()
        {
            return new Mock<IOfferRepository>();
        }

        int employerId = 1;

        Offer offer1 = new();
        Offer offer2 = new();
        Offer offer3 = new();

        List<Offer> list1 = new List<Offer>();

        IEnumerable<Offer> expectedOffer;


        [Given(@"I want to see information of the offers")]
        public void GivenIWantToSeeInformationOfTheOffers()
        {
            offer1.Id = 1; offer1.EmployerId = 1; offer1.Title = "Freelancer con tiempo";
            offer2.Id = 2; offer1.EmployerId = 1; offer1.Title = "Freelancer sin tiempo";
            offer3.Id = 3; offer1.EmployerId = 2; offer1.Title = "Freelancer con mucha experiencia";

            list1.Add(offer1); list1.Add(offer2);
            expectedOffer = list1;

        }
        
        [When(@"I choose one employerid (.*)")]
        public void WhenIChooseOneEmployer(int employerId1)
        {
            employerId = employerId1;
        }
        
        [Then(@"the system returns a list of offers")]
        public void ThenTheSystemReturnsAListOfOffers()
        {

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockOffer = GetDefaultOfferRepositoryInstance();

            mockOffer.Setup(r => r.ListByEmployerIdAsync(employerId))
                .Returns(Task.FromResult<IEnumerable<Offer>>(expectedOffer));

            

            OfferService service = new OfferService(mockOffer.Object, mockUnitOfWork.Object);

            IEnumerable<Offer> real = service.ListByEmployerId(employerId).Result;


            Assert.Equal(real, list1);


        }
    }
}
