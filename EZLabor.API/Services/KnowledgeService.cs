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
    public class KnowledgeService : IKnowledgeService
    {
        private readonly IKnowledgeRepository _knowledgeRepository;
        private readonly IFreelancerKnowledgeRepository _freelancerKnowledgeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public KnowledgeService(IKnowledgeRepository knowledgeRepository, IFreelancerKnowledgeRepository freelancerKnowledgeRepository, IUnitOfWork unitOfWork)
        {
            _knowledgeRepository = knowledgeRepository;
            _freelancerKnowledgeRepository = freelancerKnowledgeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<KnowledgeResponse> DeleteAsync(int id)
        {
            var existingKnowledge = await _knowledgeRepository.FindById(id);

            if (existingKnowledge == null)
                return new KnowledgeResponse("Knowledge not found");

            try
            {
                _knowledgeRepository.Remove(existingKnowledge);
                await _unitOfWork.CompleteAsync();

                return new KnowledgeResponse(existingKnowledge);
            }
            catch (Exception ex)
            {
                return new KnowledgeResponse($"An error ocurred while deleting the knowledge: {ex.Message}");
            }
        }

        public async Task<KnowledgeResponse> GetByIdAsync(int id)
        {
            var existingKnowledge = await _knowledgeRepository.FindById(id);

            if (existingKnowledge == null)
                return new KnowledgeResponse("Knowledge not found");
            return new KnowledgeResponse(existingKnowledge);
        }

        public async Task<IEnumerable<Knowledge>> ListAsync()
        {
            return await _knowledgeRepository.ListAsync();
        }

        public async Task<IEnumerable<Knowledge>> ListByFreelancerId(int freelancerId)
        {
            var freelancerKnowledge = await _freelancerKnowledgeRepository.ListByFreelancerIdAsync(freelancerId);
            var knowledges = freelancerKnowledge.Select(pt => pt.Knowledge).ToList();
            return knowledges;
        }

        public async Task<KnowledgeResponse> SaveAsync(Knowledge knowledge)
        {
            try
            {
                await _knowledgeRepository.AddAsync(knowledge);
                await _unitOfWork.CompleteAsync();

                return new KnowledgeResponse(knowledge);
            }
            catch (Exception ex)
            {
                return new KnowledgeResponse($"An error ocurred while saving the knowledge: {ex.Message}");
            }
        }

        public async Task<KnowledgeResponse> UpdateAsync(int id, Knowledge knowledge)
        {
            var existingKnowledge = await _knowledgeRepository.FindById(id);

            if (existingKnowledge == null)
                return new KnowledgeResponse("Knowledge not found");

            existingKnowledge.Id = knowledge.Id;

            try
            {
                _knowledgeRepository.Update(existingKnowledge);
                await _unitOfWork.CompleteAsync();

                return new KnowledgeResponse(existingKnowledge);
            }
            catch (Exception ex)
            {
                return new KnowledgeResponse($"An error ocurred while updating the knowledge: {ex.Message}");
            }
        }
    }
}
