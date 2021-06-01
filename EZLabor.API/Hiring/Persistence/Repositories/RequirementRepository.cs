
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
    public class RequirementRepository: BaseRepository, IRequirementRepository
    {
        public RequirementRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Requirement>> ListAsync()
        {
            return await _context.Requirements.ToListAsync();
        }
        public async Task<IEnumerable<Requirement>> ListByOfferIdAsync(int offerId)
        {
            return await _context.Requirements
                .Where(pt => pt.OfferId == offerId)
                .ToListAsync();
        }
       
        public async Task AddAsync(Requirement requirement)
        {
            await _context.Requirements.AddAsync(requirement);
        }

        public async Task<Requirement> FindById(int id)
        {
            return await _context.Requirements.FindAsync(id);
        }
        public void Update(Requirement requirement)
        {
            _context.Requirements.Update(requirement);
        }
        public void Remove(Requirement requirement)
        {
            _context.Requirements.Remove(requirement);
        }


    }
}
