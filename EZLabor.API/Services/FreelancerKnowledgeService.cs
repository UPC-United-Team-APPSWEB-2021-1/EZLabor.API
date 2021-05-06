using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Domain.Services;
using EZLabor.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Services
{
    public class FreelancerKnowledgeService : IFreelancerKnowledgeService
    {
        private readonly IFreelancerKnowledgeRepository _freelancerKnowledgeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FreelancerKnowledgeService(IFreelancerKnowledgeRepository freelancerKnowledgeRepository, IUnitOfWork unitOfWork)
        {
            _freelancerKnowledgeRepository = freelancerKnowledgeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<FreelancerKnowledgeResponse> AssignFreelancerKnowledgeAsync(int freelancerId, int knowledgeId)
        {
            try
            {

                await _freelancerKnowledgeRepository.AssignFreelancerKnowledge(freelancerId, knowledgeId);
                await _unitOfWork.CompleteAsync();

                FreelancerKnowledge freelancerKnowledge = await _freelancerKnowledgeRepository.FindByFreelancerIdAndKnowledgeId(freelancerId, knowledgeId);

                return new FreelancerKnowledgeResponse(freelancerKnowledge);
            }
            catch (Exception ex)
            {
                return new FreelancerKnowledgeResponse($"An error ocurred while assigning Knowledge to Freelancer: {ex.Message}");
            }
        }

        public async Task<IEnumerable<FreelancerKnowledge>> ListAsync()
        {
            return await _freelancerKnowledgeRepository.ListAsync();
        }

        public async Task<IEnumerable<FreelancerKnowledge>> ListByFreelancerIdAsync(int freelancerId)
        {
            return await _freelancerKnowledgeRepository.ListByFreelancerIdAsync(freelancerId);
        }

        public async Task<IEnumerable<FreelancerKnowledge>> ListByKnowledgeIdAsync(int knowledgeId)
        {
            return await _freelancerKnowledgeRepository.ListByKnowledgeIdAsync(knowledgeId);
        }

        public async Task<FreelancerKnowledgeResponse> UnassignFreelancerKnowledgeAsync(int freelancerId, int knowledgeId)
        {
            try
            {
                FreelancerKnowledge freelancerKnowledge = await _freelancerKnowledgeRepository.FindByFreelancerIdAndKnowledgeId(freelancerId, knowledgeId);
                _freelancerKnowledgeRepository.UnassignFreelancerKnowledge(freelancerId, knowledgeId);
                await _unitOfWork.CompleteAsync();

                return new FreelancerKnowledgeResponse(freelancerKnowledge);
            }
            catch (Exception ex)
            {
                return new FreelancerKnowledgeResponse($"An error ocurred while unassigning Knoledge to Freelancer: {ex.Message}");
            }
        }
    }
}
