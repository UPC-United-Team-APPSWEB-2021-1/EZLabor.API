using EZLabor.API.Domain.Models;
using EZLabor.API.Messaging.Domain.Model;
using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.Subscription.Domain.Model;
using System;
using System.Collections.Generic;

namespace EZLabor.API.Domain.Services.Communications
{
    public class AuthenticationResponse
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }




        public SubscriptionPlan SubscriptionPlan { get; set; }
        public int SubscriptionPlanId { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Publication> Publications { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Message> Messages { get; set; }






        public string Token { get; set; }

        public AuthenticationResponse(User user, string token)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Token = token;
        }

        public AuthenticationResponse()
        {
        }
    }
}
