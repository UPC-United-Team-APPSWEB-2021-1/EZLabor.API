﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.SocialMedia.Resources
{
    public class CommentResource
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public PublicationResource Publication { get; set; }
    }
}
