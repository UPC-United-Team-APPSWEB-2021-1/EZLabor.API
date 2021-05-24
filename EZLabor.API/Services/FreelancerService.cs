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
    public class FreelancerService: IFreelancerService
    {
        private readonly IFreelancerRepository _freelancerRepository;
        private readonly IFreelancerSkillRepository _freelancerSkillRepository;
        private readonly IProposalRepository _proposalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FreelancerService(IFreelancerRepository freelancerRepository, IFreelancerSkillRepository freelancerSkillRepository, IProposalRepository proposalRepository, IUnitOfWork unitOfWork)
        {
            _freelancerRepository = freelancerRepository;
            _freelancerSkillRepository = freelancerSkillRepository;
            _proposalRepository = proposalRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<FreelancerResponse> DeleteAsync(int id)
        {
            var existingFreelancer = await _freelancerRepository.FindById(id);

            if (existingFreelancer == null)
                return new FreelancerResponse("Freelancer not found");

            try
            {
                _freelancerRepository.Remove(existingFreelancer);
                await _unitOfWork.CompleteAsync();

                return new FreelancerResponse(existingFreelancer);
            }
            catch (Exception ex)
            {
                return new FreelancerResponse($"An error ocurred while deleting the freelancer: {ex.Message}");
            }
        }

        public async Task<FreelancerResponse> GetByIdAsync(int id)
        {
            var existingFreelancer = await _freelancerRepository.FindById(id);

            if (existingFreelancer == null)
                return new FreelancerResponse("Freelancer not found");
            return new FreelancerResponse(existingFreelancer);
        }

        public async Task<IEnumerable<Freelancer>> ListAsync()
        {
            return await _freelancerRepository.ListAsync();
        }

        public async Task<IEnumerable<Freelancer>> ListByEmployerId(int employerId)
        {
            var proposals = await _proposalRepository.ListByEmployerIdAsync(employerId);
            var freelancers = proposals.Select(pt => pt.Freelancer).ToList();
            return freelancers;
        }

        public async Task<IEnumerable<Freelancer>> ListBySkillId(int skillId)
        {
            var freelancerSkills = await _freelancerSkillRepository.ListBySkillIdAsync(skillId);
            var freelancers = freelancerSkills.Select(pt => pt.Freelancer).ToList();
            return freelancers;
        }

        public async Task<FreelancerResponse> SaveAsync(Freelancer freelancer)
        {
            try
            {
                await _freelancerRepository.AddAsync(freelancer);
                await _unitOfWork.CompleteAsync();

                return new FreelancerResponse(freelancer);
            }
            catch (Exception ex)
            {
                return new FreelancerResponse($"An error ocurred while saving the freelancer: {ex.Message}");
            }
        }

        public async Task<FreelancerResponse> UpdateAsync(int id, Freelancer freelancer)
        {
            var existingFreelancer = await _freelancerRepository.FindById(id);

            if (existingFreelancer == null)
                return new FreelancerResponse("Freelancer not found");

            existingFreelancer.UserName = freelancer.UserName;

            try
            {
                _freelancerRepository.Update(existingFreelancer);
                await _unitOfWork.CompleteAsync();

                return new FreelancerResponse(existingFreelancer);
            }
            catch (Exception ex)
            {
                return new FreelancerResponse($"An error ocurred while updating the freelancer: {ex.Message}");
            }
        }
    }
}
