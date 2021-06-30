using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Messaging.Domain.Model
{
    public class Message
    {
        public int Id { get; set; }
        public Employer Employer { get; set; }
        public int EmployerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int FreelancerId { get; set; }
        public string Content { get; set; }
    }
}
