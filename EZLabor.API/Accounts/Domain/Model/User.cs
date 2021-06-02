using EZLabor.API.SocialMedia.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Domain.Model
{
    public abstract class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<Publication> Publications { get; set; } = new List<Publication>();
        public IList<Comment> Comments { get; set; } = new List<Comment>();
        public IList<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
