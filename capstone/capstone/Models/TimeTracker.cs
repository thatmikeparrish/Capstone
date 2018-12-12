using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class TimeTracker
    {
        [Key]
        public int TimeTrackerId { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Hours { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Comments")]
        public string Comments { get; set; }
    }
}
