using AutoMapper;
using EZLabor.API.Accounts.Domain.Model;
using EZLabor.API.Accounts.Resources;
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

            CreateMap<SaveEmployerResource, Employer>();
            CreateMap<SaveFreelancerResource, Freelancer>();
            CreateMap<SaveSkillResource, Skill>();
        }
    }
}
