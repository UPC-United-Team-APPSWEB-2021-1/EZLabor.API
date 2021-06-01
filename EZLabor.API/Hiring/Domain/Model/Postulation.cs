using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Model
{
    public class Postulation
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public float Payment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string State { get; set; }


        public Offer Offer { get; set; }
        public int OfferId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int FreelancerId { get; set; }

        public List <Solution> Solutions { get; set; }
       
        public List<Meeting> Meetings { get; set; }

    }
}
