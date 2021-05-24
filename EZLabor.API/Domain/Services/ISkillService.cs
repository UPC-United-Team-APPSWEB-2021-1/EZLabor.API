using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Services
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> ListAsync();
        Task<IEnumerable<Skill>> ListByFreelancerId(int freelancerId);
        Task<SkillResponse> GetByIdAsync(int id);
        Task<SkillResponse> SaveAsync(Skill skill);
        Task<SkillResponse> UpdateAsync(int id, Skill skill);
        Task<SkillResponse> DeleteAsync(int id);
    }
}
