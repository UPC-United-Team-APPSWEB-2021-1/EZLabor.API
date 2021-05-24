using AutoMapper;
using EZLabor.API.Domain.Models;
using EZLabor.API.Resources;
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
            CreateMap<User,SaveUserResource> ();
            CreateMap<Employer, SaveEmployerResource > ();
            CreateMap<Freelancer, SaveFreelancerResource> ();
            CreateMap<Skill, SaveSkillResource> ();
        }
        
    }
}
