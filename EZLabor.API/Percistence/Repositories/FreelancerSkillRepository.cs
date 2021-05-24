using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Persistence.Contexts;
using EZLabor.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Percistence.Repositories
{
    public class FreelancerSkillRepository : BaseRepository, IFreelancerSkillRepository
    {
        public FreelancerSkillRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(FreelancerSkill freelancerSkill)
        {
            await _context.FreelancerSkills.AddAsync(freelancerSkill);
        }

        public async Task AssignFreelancerSkill(int freelancerId, int skillId)
        {
            FreelancerSkill freelancerSkill = await FindByFreelancerIdAndSkillId(freelancerId, skillId);
            if (freelancerSkill == null)
            {
                freelancerSkill = new FreelancerSkill { FreelancerId = freelancerId, SkillId = skillId };
                await AddAsync(freelancerSkill);
            }
        }

        public async Task<FreelancerSkill> FindByFreelancerIdAndSkillId(int freelancerId, int skillId)
        {
            return await _context.FreelancerSkills.FindAsync(freelancerId, skillId);
        }

        public async Task<IEnumerable<FreelancerSkill>> ListAsync()
        {
            return await _context.FreelancerSkills
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Skill)
                .ToListAsync();
        }

        public async Task<IEnumerable<FreelancerSkill>> ListByFreelancerIdAsync(int freelancerId)
        {
            return await _context.FreelancerSkills
                .Where(pt => pt.FreelancerId == freelancerId)
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Skill)
                .ToListAsync();
        }

        public async Task<IEnumerable<FreelancerSkill>> ListBySkillIdAsync(int skillId)
        {
            return await _context.FreelancerSkills
                .Where(pt => pt.SkillId == skillId)
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Skill)
                .ToListAsync();
        }

        public void Remove(FreelancerSkill freelancerSkill)
        {
            _context.FreelancerSkills.Remove(freelancerSkill);
        }

        public async void UnassignFreelancerSkill(int freelancerId, int skillId)
        {
            FreelancerSkill freelancerSkill = await _context.FreelancerSkills.FindAsync(freelancerId, skillId);
            if (freelancerSkill != null)
                Remove(freelancerSkill);
        }
    }
}
