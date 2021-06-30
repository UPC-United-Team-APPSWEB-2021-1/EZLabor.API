
using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Model
{
    public class Publication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime UploadAt { get; set; }
        public string VideoUrl { get; set; }

        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        public IList<Comment> Comments { get; set; } = new List<Comment>();
    }
}
