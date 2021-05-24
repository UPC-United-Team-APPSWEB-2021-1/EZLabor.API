using AutoMapper;
using EZLabor.API.Domain.Models;
using EZLabor.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Mapping
{
    public class ResourceToModelProfile: Profile
    {  
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveEmployerResource, Employer>();
            CreateMap<SaveFreelancerResource, Freelancer>();
            CreateMap<SaveSkillResource, Skill>();
        }
    }
}
