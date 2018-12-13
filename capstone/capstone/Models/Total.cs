using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class Total
    {
        [Key]
        public int TotalId { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Material Cost")]
        public int? MaterialCost { get; set; }

        [Display(Name = "Material Margin")]
        public int? MaterialMargin { get; set; }

        [Display(Name = "Material Quote")]
        public int? MaterialQuote { get; set; }

        [Display(Name = "Subcontract Cost")]
        public int? SubCost { get; set; }

        [Display(Name = "Subcontract Quote")]
        public int? SubQuote { get; set; }

        public int? ManHours { get; set; }

        [Display(Name = "Unburdened Rate")]
        public int? UnburdenedRate { get; set; }

        public int? Insurance { get; set; }

        [Display(Name = "Labor Total")]
        public int? LaborTotal { get; set; }

        public int? Travel { get; set; }

        public int? Consumables { get; set; }

        [Display(Name = "Install Quote")]
        public int? InstallQuote { get; set; }

        [Display(Name = "Composite Labor")]
        public int? CompositeLabor { get; set; }

        [Display(Name = "Install Quote Total")]
        public int? InstallQuoteTotal { get; set; }

        [Display(Name = "Sales Tax")]
        public int? SalesTax { get; set; }

        public int? Totals { get; set; }
    }
}
