
using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public Publication Publication { get; set; }
        public int PublicationId { get; set; }
        public string Content { get; set; }

        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}
