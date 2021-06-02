using EZLabor.API.Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Domain.Model
{
    public class Notification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime NotificationTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
