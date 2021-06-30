
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
        public string Password { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public int SubscriptionPlanId { get; set; }
    }
}
