using EZLabor.API.Messaging.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Messaging.Domain.Persistence.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> ListAsync();
        Task<IEnumerable<Message>> ListByFreelancerIdAsync(int freelancerId);
        Task<IEnumerable<Message>> ListByEmployerIdAsync(int employerId);
        Task<IEnumerable<Message>> ListByFreelancerIdAndEmployerIdAsync(int freelancerId, int employerId);
        Task AddAsync(Message message);
        Task<Message> FindByIdAndFreelancerIdAndEmployerId(int id, int freelancerId, int employerId);
        void Update(Message message);
        void Remove(Message message);
    }
}
