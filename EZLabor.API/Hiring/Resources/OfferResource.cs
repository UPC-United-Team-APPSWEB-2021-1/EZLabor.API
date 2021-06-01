using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Resources
{
    public class OfferResource
    {

        public int Id { get; set; }

        public int EmployerId { get; set; }

        public float Payment { get; set; }

        public DateTime CreatedAt { get; set; }

        public string State { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }


    }
}
