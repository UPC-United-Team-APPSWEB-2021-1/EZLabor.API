using EZLabor.API.Hiring.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Resources
{
    public class QualificationResource
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Stars { get; set; }
        public SolutionResource Solution { get; set; }
    }
}
