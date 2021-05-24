using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Persistence.Repositories
{
    public interface IFreelancerSkillRepository
    {
        Task<IEnumerable<FreelancerSkill>> ListAsync();
        Task<IEnumerable<FreelancerSkill>> ListByFreelancerIdAsync(int freelancerId);
        Task<IEnumerable<FreelancerSkill>> ListBySkillIdAsync(int skillId);
        Task<FreelancerSkill> FindByFreelancerIdAndSkillId(int freelancerId, int skillId);
        Task AddAsync(FreelancerSkill freelancerSkill);
        void Remove(FreelancerSkill freelancerSkill);
        Task AssignFreelancerSkill(int freelancerId, int skillId);
        void UnassignFreelancerSkill(int freelancerId, int skillId);
    }
}
