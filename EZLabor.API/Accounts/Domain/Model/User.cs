using EZLabor.API.Messaging.Domain.Model;
using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.Subscription.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string Token { get; set; }


        public SubscriptionPlan SubscriptionPlan { get; set; }
        public int SubscriptionPlanId { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Publication> Publications { get; set; }
        public List<Notification> Notifications { get; set; } 
        public List<Message> Messages { get; set; }
    }
}
