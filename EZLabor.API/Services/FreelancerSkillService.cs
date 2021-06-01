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
    public class FreelancerSkillService : IFreelancerSkillService
    {
        private readonly IFreelancerSkillRepository _freelancerSkillRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FreelancerSkillService(IFreelancerSkillRepository freelancerSkillRepository, IUnitOfWork unitOfWork)
        {
            _freelancerSkillRepository = freelancerSkillRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<FreelancerSkillResponse> AssignFreelancerSkillAsync(int freelancerId, int skillId)
        {
            try
            {

                await _freelancerSkillRepository.AssignFreelancerSkill(freelancerId, skillId);
                await _unitOfWork.CompleteAsync();

                FreelancerSkill freelancerSkill = await _freelancerSkillRepository.FindByFreelancerIdAndSkillId(freelancerId, skillId);

                return new FreelancerSkillResponse(freelancerSkill);
            }
            catch (Exception ex)
            {
                return new FreelancerSkillResponse($"An error ocurred while assigning Skill to Freelancer: {ex.Message}");
            }
        }

        public async Task<IEnumerable<FreelancerSkill>> ListAsync()
        {
            return await _freelancerSkillRepository.ListAsync();
        }

        public async Task<IEnumerable<FreelancerSkill>> ListByFreelancerIdAsync(int freelancerId)
        {
            return await _freelancerSkillRepository.ListByFreelancerIdAsync(freelancerId);
        }

        public async Task<IEnumerable<FreelancerSkill>> ListBySkillIdAsync(int skillId)
        {
            return await _freelancerSkillRepository.ListBySkillIdAsync(skillId);
        }

        public async Task<FreelancerSkillResponse> UnassignFreelancerSkillAsync(int freelancerId, int skillId)
        {
            try
            {
                FreelancerSkill freelancerSkill = await _freelancerSkillRepository.FindByFreelancerIdAndSkillId(freelancerId, skillId);
                _freelancerSkillRepository.UnassignFreelancerSkill(freelancerId, skillId);
                await _unitOfWork.CompleteAsync();

                return new FreelancerSkillResponse(freelancerSkill);
            }
            catch (Exception ex)
            {
                return new FreelancerSkillResponse($"An error ocurred while unassigning Knoledge to Freelancer: {ex.Message}");
            }
        }
    }
}
