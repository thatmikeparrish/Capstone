using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class WorkforceCalc
    {
        [Key]
        public int WorkforceCalcId { get; set; }

        public int? EmployeePayRateId { get; set; }

        public EmployeeTypePayRate EmployeeTypePayRate { get; set; }

        [Display(Name = "Working Days")]
        public double? WorkingDays { get; set; }

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
