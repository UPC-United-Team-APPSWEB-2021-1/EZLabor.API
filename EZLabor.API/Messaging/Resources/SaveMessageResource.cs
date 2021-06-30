using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Messaging.Resources
{
    public class SaveMessageResource
    {
        [Required]
        public string Content { get; set; }
    }
}
