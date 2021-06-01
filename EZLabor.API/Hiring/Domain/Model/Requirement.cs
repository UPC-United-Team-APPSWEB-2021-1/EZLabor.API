using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Domain.Model
{
    public class Requirement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SkillLevel { get; set; }


        public Offer Offer { get; set; }
        public int OfferId { get; set; }
    }
}
