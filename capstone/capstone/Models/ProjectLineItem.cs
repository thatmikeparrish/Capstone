using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class ProjectLineItem
    {
        [Key]
        public int ProjectLineItemId { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int LineItemId { get; set; }
    }
}
