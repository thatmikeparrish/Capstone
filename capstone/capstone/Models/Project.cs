using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        [Required]
        [StringLength(6)]
        public string ProjectNumber { get; set; }

        public int? MarginsId { get; set; }

        public int? TotalId { get; set; }

        public int? WorkforceId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CompletionDate { get; set; }

        public bool? IsCompleted { get; set; }

        public int? TimeTrackerId { get; set; }
    }
}
