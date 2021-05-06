using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Persistence.Repositories
{
    public interface IKnowledgeRepository
    {
        Task<IEnumerable<Knowledge>> ListAsync();
        Task AddAsync(Knowledge knowledge);
        Task<Knowledge> FindById(int id);
        void Update(Knowledge knowledge);
        void Remove(Knowledge knowledge);
    }
}
