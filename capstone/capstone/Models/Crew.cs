using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class Crew
    {
        [Key]
        public int CrewId { get; set; }

        [Required]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Employee Type")]
        public int EmployeeTypeId { get; set; }

        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Pay Rate")]
        public double? PayRate { get; set; }

        [Display(Name = "Quantity")]
        public double? EmployeeQuantity { get; set; }

        [Display(Name = "Managment Hours")]
        public double? ManagmentHours { get; set; }

        [Display(Name = "Managment Cost")]
        public double? ManagmentCost { get; set; }

        [Display(Name = "Labor Hours")]
        public double? LaborHours { get; set; }

        [Display(Name = "Labor Cost")]
        public double? LaborCost { get; set; }
    }
}
