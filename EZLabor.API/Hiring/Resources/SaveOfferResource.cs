using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Hiring.Resources
{
    public class SaveOfferResource
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int EmployerId { get; set; }

        [Required]
        public float Payment { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public int Duration { get; set; }

    }
}
