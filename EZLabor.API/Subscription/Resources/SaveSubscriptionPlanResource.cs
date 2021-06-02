using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Subscription.Resources
{
    public class SaveSubscriptionPlanResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
