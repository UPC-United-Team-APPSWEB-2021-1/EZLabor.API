using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Resources
{
    public class SaveCommentResource
    {
        [Required]
        [MaxLength(30)]
        public string Content { get; set; }
    }
}
