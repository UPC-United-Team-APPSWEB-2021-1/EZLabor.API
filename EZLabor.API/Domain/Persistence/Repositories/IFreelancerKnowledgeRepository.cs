using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Persistence.Repositories
{
    public interface IFreelancerKnowledgeRepository
    {
        Task<IEnumerable<FreelancerKnowledge>> ListAsync();
        Task<IEnumerable<FreelancerKnowledge>> ListByFreelancerIdAsync(int freelancerId);
        Task<IEnumerable<FreelancerKnowledge>> ListByKnowledgeIdAsync(int knowledgeId);
        Task<FreelancerKnowledge> FindByFreelancerIdAndKnowledgeId(int freelancerId, int knowledgeId);
        Task AddAsync(FreelancerKnowledge freelancerKnowledge);
        void Remove(FreelancerKnowledge freelancerKnowledge);
        Task AssignFreelancerKnowledge(int freelancerId, int knowledgeId);
        void UnassignFreelancerKnowledge(int freelancerId, int knowledgeId);
    }
}
