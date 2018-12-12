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
        public int EmployeeTypeId { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public double? UnburdenedPayRate { get; set; }

        public int? EmployeeQuantity { get; set; }
    }
}
