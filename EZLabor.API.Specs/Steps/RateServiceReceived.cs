
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace EZLabor.API.Specs.Steps
{
    [Binding]
    public sealed class RateServiceReceived
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public RateServiceReceived(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("it is on the freelancer rating pop-up screen")]
        public void GivenItIsOnTheFreelancerRatingPopUpScreen()
        {
            

            _scenarioContext.Pending();
        }


        [When("is chosen which rating and feedback to give the freelancer")]
        public void WhenIsChosenWhichRatingAndFeedbackToGiveTheFreelancer()
        {
            int rating = 5;


            _scenarioContext.Pending();
        }

        [Then("the system sends the rating and notifies the company that their rating was successfully processed")]
        public void ThenTheSystemSendsTheRatingAndNotifiesTheCompanyThatTheirRatingWasSuccessfullyProcessed(int result)
        {
            

            _scenarioContext.Pending();
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
