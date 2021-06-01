
using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Persistence.Context;
using EZLabor.API.Hiring.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Persistence.Repositories
{
    public class SolutionRepository:BaseRepository, ISolutionRepository
    {
        public SolutionRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Solution>> ListAsync()
        {
            return await _context.Solutions.ToListAsync();
        }
       
        public async Task AddAsync(Solution solution)
        {
            await _context.Solutions.AddAsync(solution);
        }

        public async Task<Solution> FindById(int id)
        {
            return await _context.Solutions.FindAsync(id);
        }
        public void Update(Solution solution)
        {
            _context.Solutions.Update(solution);
        }
        public void Remove(Solution solution)
        {
            _context.Solutions.Remove(solution);
        }
    }

}
