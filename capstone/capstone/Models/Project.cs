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
        [Display(Name = "Client Name")]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Project Number")]
        public string ProjectNumber { get; set; }

        public double? SalesTax { get; set; }

        public int? MarginsId { get; set; }

        public int? TotalId { get; set; }

        public int? WorkforceId { get; set; }

        public WorkforceCalc WorkforceCalc { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Completion Date")]
        public DateTime? CompletionDate { get; set; }

        [Display(Name = "Complete?")]
        public bool? IsCompleted { get; set; }

        public int? TimeTrackerId { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set;}
    }
}
