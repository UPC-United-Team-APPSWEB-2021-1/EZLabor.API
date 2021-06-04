
using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Model
{
    public class Follow
    {
        public Employer Employer { get; set; }
        public int EmployerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int FreelancerId { get; set; }
    }
}
