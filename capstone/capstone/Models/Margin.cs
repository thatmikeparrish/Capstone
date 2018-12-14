using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class Margin
    {
        [Key]
        public int MarginId { get; set; }

        [Display(Name = "Unburdened Rate")]
        public double? UnburdenedRate { get; set; }

        public double? Insurance { get; set; }

        [Display(Name = "Labor Total")]
        public double? LaborTotal { get; set; }

        public double? Travel { get; set; }

        public double? Consumables { get; set; }

        public double? Equipment { get; set; }

        [Display(Name = "Composite Labor")]
        public double? CompositeLabor { get; set; }
    }
}
