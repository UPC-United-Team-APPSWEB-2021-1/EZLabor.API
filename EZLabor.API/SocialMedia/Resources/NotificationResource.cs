﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Resources
{
    public class NotificationResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime NotificationTime { get; set; }
    }
}
