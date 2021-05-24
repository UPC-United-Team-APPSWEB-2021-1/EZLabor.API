using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Services
{
    public interface IFreelancerSkillService
    {
        Task<IEnumerable<FreelancerSkill>> ListAsync();
        Task<IEnumerable<FreelancerSkill>> ListByFreelancerIdAsync(int freelancerId);
        Task<IEnumerable<FreelancerSkill>> ListBySkillIdAsync(int skillId);
        Task<FreelancerSkillResponse> AssignFreelancerSkillAsync(int freelancerId, int skillId);
        Task<FreelancerSkillResponse> UnassignFreelancerSkillAsync(int freelancerId, int skillId);
    }
}
