using AutoMapper;
using EZLabor.API.Domain.Models;
using EZLabor.API.Hiring.Domain.Model;
using EZLabor.API.Hiring.Resources;
using EZLabor.API.Messaging.Domain.Model;
using EZLabor.API.Messaging.Resources;
using EZLabor.API.Resources;
using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.SocialMedia.Resources;
using EZLabor.API.Subscription.Domain.Model;
using EZLabor.API.Subscription.Resources;
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

            CreateMap<SaveMeetingResource, Meeting>();
            CreateMap<SaveOfferResource, Offer>();
            CreateMap<SavePostulationResource, Postulation>();
            CreateMap<SaveRequirementResource, Requirement>();
            CreateMap<SaveSolutionResource, Solution>();

            CreateMap<SaveCommentResource, Comment>();
            CreateMap<SaveNotificationResource, Notification>();
            CreateMap <SavePublicationResource, Publication>();
            CreateMap<SaveQualificationResource, Qualification>();

            CreateMap<SaveSubscriptionPlanResource, SubscriptionPlan>();

            CreateMap<SaveMessageResource, Message>();
        }
    }
}
