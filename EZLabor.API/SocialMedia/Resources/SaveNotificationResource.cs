using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Resources
{
    public class SaveNotificationResource
    {
        [Required]
        [MaxLength(30)]
        public string Description { get; set; }
    }
}
