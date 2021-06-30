using EZLabor.API.Domain.Persistence.Contexts;
using EZLabor.API.Messaging.Domain.Model;
using EZLabor.API.Messaging.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Messaging.Persistence.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }


        public async Task<Message> FindByIdAndFreelancerIdAndEmployerId(int id, int freelancerId, int employerId)
        {
            return await _context.Messages.FindAsync(id, employerId, freelancerId);
        }

        public async Task<IEnumerable<Message>> ListAsync()
        {
            return await _context.Messages
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Employer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> ListByEmployerIdAsync(int employerId)
        {
            return await _context.Messages
                .Where(pt => pt.EmployerId == employerId)
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Employer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> ListByFreelancerIdAndEmployerIdAsync(int freelancerId, int employerId)
        {
            return await _context.Messages
                .Where(pt => pt.EmployerId == employerId && pt.FreelancerId == freelancerId)
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Employer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> ListByFreelancerIdAsync(int freelancerId)
        {
            return await _context.Messages
                .Where(pt => pt.FreelancerId == freelancerId)
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Employer)
                .ToListAsync();
        }

        public void Remove(Message message)
        {
            _context.Messages.Remove(message);
        }

        public void Update(Message message)
        {
            _context.Messages.Update(message);
        }
    }
}
