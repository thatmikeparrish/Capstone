using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class EmployeeTypePayRate
    {
        [Key]
        public int EmployeeTypePayRateId { get; set; }

        [Required]
        [Display(Name = "Employee Type")]
        public int EmployeeTypeId { get; set; }

        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Unburdened Pay Rate")]
        public double? UnburdenedPayRate { get; set; }

        [Display(Name = "Employee Quantity")]
        public int? EmployeeQuantity { get; set; }
    }
}
