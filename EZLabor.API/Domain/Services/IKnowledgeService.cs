using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Services
{
    public interface IKnowledgeService
    {
        Task<IEnumerable<Knowledge>> ListAsync();
        Task<IEnumerable<Knowledge>> ListByFreelancerId(int freelancerId);
        Task<KnowledgeResponse> GetByIdAsync(int id);
        Task<KnowledgeResponse> SaveAsync(Knowledge knowledge);
        Task<KnowledgeResponse> UpdateAsync(int id, Knowledge knowledge);
        Task<KnowledgeResponse> DeleteAsync(int id);
    }
}
