using EZLabor.API.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Model
{
    public class Publication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime UploadAt { get; set; }
        public string VideoUrl { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public IList<Comment> Comments { get; set; } = new List<Comment>();
    }
}
