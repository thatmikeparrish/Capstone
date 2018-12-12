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

        public int? UnburdenedRate { get; set; }

        public int? Insurance { get; set; }

        public int? LaborTotal { get; set; }

        public int? Travel { get; set; }

        public int? Consumables { get; set; }

        public int? Equipment { get; set; }

        public int? CompositeLabor { get; set; }
    }
}
