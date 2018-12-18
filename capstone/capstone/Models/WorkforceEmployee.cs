using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class WorkforceEmployee
    {
        [Key]
        public int WorkforceEmployeeId { get; set; }

        public int? WorkforceCalcId { get; set; }

        public WorkforceCalc WorkforceCalc { get; set; }

        public int? EmployeeTypePayRateId { get; set; }

        public WorkforceCalc EmployeeTypePayRate { get; set; }
    }
}
