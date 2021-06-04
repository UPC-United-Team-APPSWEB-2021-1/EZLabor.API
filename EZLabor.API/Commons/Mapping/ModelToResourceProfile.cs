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
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            
            CreateMap<Employer, SaveEmployerResource>();
            CreateMap<Freelancer, SaveFreelancerResource>();
            CreateMap<Skill, SaveSkillResource>();

            CreateMap<Meeting, SaveMeetingResource>();
            CreateMap<Offer, SaveOfferResource>();
            CreateMap<Postulation, SavePostulationResource>();
            CreateMap<Requirement, SaveRequirementResource>();
            CreateMap<Solution, SaveSolutionResource>();

            CreateMap<Comment, SaveCommentResource>();
            CreateMap<Notification, SaveNotificationResource>();
            CreateMap<Publication, SavePublicationResource>();
            CreateMap<Qualification, SaveQualificationResource>();

            CreateMap<SubscriptionPlan, SaveSubscriptionPlanResource>();

            CreateMap<Message, SaveMessageResource>();
        }
        
    }
}
