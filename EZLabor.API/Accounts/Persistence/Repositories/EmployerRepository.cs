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
    public class EmployerRepository : BaseRepository, IEmployerRepository
    {
        public EmployerRepository(AppDbContext context): base(context)
        {
        }
        public async Task AddAsync(Employer employer)
        {
            await _context.Employers.AddAsync(employer);
        }

        public async Task<Employer> FindById(int id)
        {
            return await _context.Employers.FindAsync(id);
        }

        public async Task<IEnumerable<Employer>> ListAsync()
        {
            return await _context.Employers.ToListAsync();
        }

        public void Remove(Employer employer)
        {
            _context.Employers.Remove(employer);
        }

        public void Update(Employer employer)
        {
            _context.Employers.Update(employer);
        }
    }
}
