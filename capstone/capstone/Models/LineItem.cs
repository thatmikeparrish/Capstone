using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class LineItem
    {
        [Key]
        public int LineItemId { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public int? MaterialCost { get; set; }

        public int? MaterialMargin { get; set; }

        public int? MaterialQuote { get; set; }

        public int? SubCost { get; set; }

        public int? SubQuote { get; set; }

        public int? ManHours { get; set; }

        public int? UnburdenedRate { get; set; }

        public int? Insurance { get; set; }

        public int? LaborTotal { get; set; }

        public int? Travel { get; set; }

        public int? Consumables { get; set; }

        public int? InstallQuote { get; set; }

        public int? CompositeLabor { get; set; }

        public int? InstallQuoteTotal { get; set; }

        public int? SalesTax { get; set; }

        public int? Totals { get; set; }
    }
}
