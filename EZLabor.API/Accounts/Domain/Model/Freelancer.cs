using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Model
{
    public class Freelancer : User
    {
        public int Rating { get; set; }
        public string Specially { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Proposal> Proposals { get; set; }

        public List<Postulation> Postulations { get; set; }

    }
}
