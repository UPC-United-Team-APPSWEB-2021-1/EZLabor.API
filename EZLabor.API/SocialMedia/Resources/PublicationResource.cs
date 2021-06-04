using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Resources
{
    public class PublicationResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime UploadAt { get; set; }
        public string VideoUrl { get; set; }
    }
}
