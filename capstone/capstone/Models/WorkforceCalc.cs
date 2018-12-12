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

        public int? ManagmentHours { get; set; }

        public int? ManagmentCost { get; set; }

        public int? LaborHours { get; set; }

        public int? LaborCost { get; set; }
    }
}
