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
    public class FreelancerKnowledgeRepository: BaseRepository, IFreelancerKnowledgeRepository
    {
        public FreelancerKnowledgeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(FreelancerKnowledge freelancerKnowledge)
        {
            await _context.FreelancerKnowledges.AddAsync(freelancerKnowledge);
        }

        public async Task AssignFreelancerKnowledge(int freelancerId, int knowledgeId)
        {
            FreelancerKnowledge freelancerKnowledge = await FindByFreelancerIdAndKnowledgeId(freelancerId, knowledgeId);
            if (freelancerKnowledge == null)
            {
                freelancerKnowledge = new FreelancerKnowledge { FreelancerId = freelancerId, KnowledgeId = knowledgeId };
                await AddAsync(freelancerKnowledge);
            }
        }

        public async Task<FreelancerKnowledge> FindByFreelancerIdAndKnowledgeId(int freelancerId, int knowledgeId)
        {
            return await _context.FreelancerKnowledges.FindAsync(freelancerId, knowledgeId);
        }

        public async Task<IEnumerable<FreelancerKnowledge>> ListAsync()
        {
            return await _context.FreelancerKnowledges
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Knowledge)
                .ToListAsync();
        }

        public async Task<IEnumerable<FreelancerKnowledge>> ListByFreelancerIdAsync(int freelancerId)
        {
            return await _context.FreelancerKnowledges
                .Where(pt => pt.FreelancerId == freelancerId)
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Knowledge)
                .ToListAsync();
        }

        public async Task<IEnumerable<FreelancerKnowledge>> ListByKnowledgeIdAsync(int knowledgeId)
        {
            return await _context.FreelancerKnowledges
                .Where(pt => pt.KnowledgeId == knowledgeId)
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Knowledge)
                .ToListAsync();
        }

        public void Remove(FreelancerKnowledge freelancerKnowledge)
        {
            _context.FreelancerKnowledges.Remove(freelancerKnowledge);
        }

        public async void UnassignFreelancerKnowledge(int freelancerId, int knowledgeId)
        {
            FreelancerKnowledge freelancerKnowledge = await _context.FreelancerKnowledges.FindAsync(freelancerId, knowledgeId);
            if (freelancerKnowledge != null)
                Remove(freelancerKnowledge);
        }
    }
}
