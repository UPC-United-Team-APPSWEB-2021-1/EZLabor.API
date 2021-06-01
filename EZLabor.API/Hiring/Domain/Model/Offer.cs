using EZLabor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Model
{
    public class Offer
    {
        public int Id { get; set; }

        public float Payment { get; set; }

        public DateTime CreatedAt { get; set; }

        public string State { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        public List<Requirement> Requirements { get; set; }

        public Employer Employer { get; set; }
        public int EmployerId { get; set; }

        public List<Postulation> Postulations { get; set; }


    }
}
