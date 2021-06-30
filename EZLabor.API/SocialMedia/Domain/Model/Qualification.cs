using EZLabor.API.Hiring.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Model
{
    public class Qualification
    {
        public int Id { get; set; }
        public Solution Solution { get; set; }
        public int SolutionId { get; set; }
        public string Comment { get; set; }
        public int Stars { get; set; }
    }
}
