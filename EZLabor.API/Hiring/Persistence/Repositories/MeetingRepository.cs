
using EZLabor.API.Domain.Persistence.Contexts;
using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Persistence.Repositories
{
    public class MeetingRepository: BaseRepository, IMeetingRepository
    {
        public MeetingRepository(AppDbContext context):base(context)
        {

        }
        public async Task AddAsync(Meeting meeting)
        {
            await _context.Meetings.AddAsync(meeting);
        }

        public async Task<Meeting> FindById(int id)
        {
            return await _context.Meetings.FindAsync(id);
        }

        public async Task<IEnumerable<Meeting>> ListAsync()
        {
            return await _context.Meetings.ToListAsync();
        }
        public async Task<IEnumerable<Meeting>> ListByPostulationIdAsync(int postulationId)
        {
            return await _context.Meetings
                .Where(pt => pt.PostulationId == postulationId)
                .ToListAsync();
        }


        public void Remove(Meeting meeting)
        {
            _context.Meetings.Remove(meeting);
        }

        public void Update(Meeting meeting)
        {
            _context.Meetings.Update(meeting);
        }

    }
}
