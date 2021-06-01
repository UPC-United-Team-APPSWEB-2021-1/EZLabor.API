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
    public class FreelancerRepository: BaseRepository, IFreelancerRepository
    {
        public FreelancerRepository(AppDbContext context): base(context)
        {
        }

        public async Task AddAsync(Freelancer freelancer)
        {
            await _context.Freelancers.AddAsync(freelancer);
        }

        public async Task<Freelancer> FindById(int id)
        {
            return await _context.Freelancers.FindAsync(id);
        }

        public async Task<IEnumerable<Freelancer>> ListAsync()
        {
            return await _context.Freelancers.ToListAsync();
        }

        public void Remove(Freelancer freelancer)
        {
            _context.Freelancers.Remove(freelancer);
        }

        public void Update(Freelancer freelancer)
        {
            _context.Freelancers.Update(freelancer);
        }
    }
}
