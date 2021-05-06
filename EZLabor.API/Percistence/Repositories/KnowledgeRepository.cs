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
    public class KnowledgeRepository : BaseRepository, IKnowledgeRepository
    {
        public KnowledgeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Knowledge knowledge)
        {
            await _context.Knowledges.AddAsync(knowledge);
        }

        public async Task<Knowledge> FindById(int id)
        {
            return await _context.Knowledges.FindAsync(id);
        }

        public async Task<IEnumerable<Knowledge>> ListAsync()
        {
            return await _context.Knowledges.ToListAsync();
        }

        public void Remove(Knowledge knowledge)
        {
            _context.Knowledges.Remove(knowledge);
        }

        public void Update(Knowledge knowledge)
        {
            _context.Knowledges.Update(knowledge);
        }
    }
}
