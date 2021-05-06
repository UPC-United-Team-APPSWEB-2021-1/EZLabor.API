using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Services
{
    public interface IFreelancerKnowledgeService
    {
        Task<IEnumerable<FreelancerKnowledge>> ListAsync();
        Task<IEnumerable<FreelancerKnowledge>> ListByFreelancerIdAsync(int freelancerId);
        Task<IEnumerable<FreelancerKnowledge>> ListByKnowledgeIdAsync(int knowledgeId);
        Task<FreelancerKnowledgeResponse> AssignFreelancerKnowledgeAsync(int freelancerId, int knowledgeId);
        Task<FreelancerKnowledgeResponse> UnassignFreelancerKnowledgeAsync(int freelancerId, int knowledgeId);
    }
}
