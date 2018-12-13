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

        [Display(Name = "Managment Hours")]
        public int? ManagmentHours { get; set; }

        [Display(Name = "Managment Cost")]
        public int? ManagmentCost { get; set; }

        [Display(Name = "Labor Hours")]
        public int? LaborHours { get; set; }

        [Display(Name = "Labor Cost")]
        public int? LaborCost { get; set; }
    }
}
