using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Domain.Services;
using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.Services;
using Moq;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace EZLabor.API.Specs.Steps
{
    [Binding]
    public class EditProfileSteps
    {
        public readonly ScenarioContext _scenarioContext;
        private Freelancer _freelancer = new();
        private Freelancer _updatedFreelancer = new();
        private Task<FreelancerResponse> _response;

        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
        
        public EditProfileSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private static Mock<IFreelancerRepository> _freelancerRepository = new Mock<IFreelancerRepository>();

        private IFreelancerService _freelancerService = new FreelancerService(_freelancerRepository.Object,
            GetDefaultIProposalRepositoryInstance().Object, GetDefaultIUnitOfWorkInstance().Object);

        [Given(@"I create an freelancer account")]
        public void GivenICreateAnFreelancerAccount(string Id, int Rating, string Specially)
        {
            int realId = Int32.Parse(Id);
            _freelancer.Id = realId;
            _freelancer.Rating = Rating;
            _freelancer.Specially = Specially;                        

            _freelancerRepository.Setup(r => r.FindById(realId))
               .Returns(Task.FromResult<Freelancer>(_freelancer));
        }
        
        [When(@"I update the personal data")]
        public void WhenIUpdateThePersonalData(string Id, int newRating, string newSpecially)
        {
            int sameId = Int32.Parse(Id);
            Freelancer newFreelancer = new()
            {
                Rating = newRating,
                Specially = newSpecially                
            };
            _response = _freelancerService.UpdateAsync(sameId, newFreelancer);
            Assert.AreEqual(newFreelancer.Rating, _response.Result.Resource.Rating);
        }
        
        [Then(@"The updated info should return")]
        public void ThenTheUpdatedInfoShouldReturn(string actualResponse)
        {
            string a = _response.Result.Success.ToString();
            Assert.AreEqual(a, actualResponse);
        }
    }
}
