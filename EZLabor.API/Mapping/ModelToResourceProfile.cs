using AutoMapper;
using EZLabor.API.Accounts.Domain.Model;
using EZLabor.API.Accounts.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            
            CreateMap<Employer, SaveEmployerResource > ();
            CreateMap<Freelancer, SaveFreelancerResource> ();
            CreateMap<Skill, SaveSkillResource> ();
        }
        
    }
}
