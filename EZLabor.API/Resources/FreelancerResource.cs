using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Resources
{
    public class FreelancerResource: UserResource
    {
        public int Rating { get; set; }
        public string Specially { get; set; }
    }
}
