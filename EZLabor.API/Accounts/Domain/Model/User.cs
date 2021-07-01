
﻿using EZLabor.API.Subscription.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public SubscriptionPlan SubscriptionPlan { get; set; }
        public int SubscriptionPlanId { get; set; }
        public string ImageUrl { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public string Token { get; set; }
    }
}
