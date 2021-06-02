using EZLabor.API.Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public Publication Publication { get; set; }
        public int PublicationId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
