using capstone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class LineItem
    {
        [Key]
        public int LineItemId { get; set; }

        [Required]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Material Cost")]
        public double? MaterialCost { get; set; }

        [Display(Name = "Material Margin")]
        public double? MaterialMargin
        {
            get
            {
                if (MaterialCost >= 50000) {
                    return .10;
                }
                else if (MaterialCost >= 20000)
                {
                    return .10;
                }
                else if (MaterialCost >= 5000)
                {
                    return .15;
                }
                else if (MaterialCost >= 1000)
                {
                    return .20;
                }
                else if (MaterialCost >= 500)
                {
                    return .50;
                }
                else if (MaterialCost >= 100)
                {
                    return .75;
                }
                else if (MaterialCost >= 0)
                {
                    return 1;
                }
                else 
                {
                    return 0;
                }
            }
        }

        [NotMapped]
        [Display(Name = "Material Quote")]
        public double? MaterialQuote
        {
            get
            {
                if (MaterialCost == null)
                {
                    return 0;
                }
                else
                {
                    return MaterialCost * (1 + MaterialMargin);
                }
            }
        }

        [Display(Name = "Subcontract Cost")]
        public double? SubCost { get; set; }

        [Display(Name = "Subcontract Margin")]
        public double? SubMargin
        {
            get
            {
                if (SubCost >= 50000)
                {
                    return .10;
                }
                else if (SubCost >= 20000)
                {
                    return .10;
                }
                else if (SubCost >= 5000)
                {
                    return .15;
                }
                else if (SubCost >= 1000)
                {
                    return .20;
                }
                else if (SubCost >= 500)
                {
                    return .50;
                }
                else if (SubCost >= 100)
                {
                    return .75;
                }
                else if (SubCost >= 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        [NotMapped]
        [Display(Name = "Subcontract Quote")]
        public double? SubQuote
        {
            get
            {
                if (SubCost == null)
                {
                    return 0;
                }
                else
                {
                    return SubCost * (1 + SubMargin);
                }
            }
        }

        public double? ManHours { get; set; }

        [NotMapped]
        [Display(Name = "Labor Cost")]
        public double? LaborCost { get; set; }

        [NotMapped]
        [Display(Name = "Labor Quote")]
        public double? LaborQuote { get; set; }

        [NotMapped]
        [Display(Name = "Sales Tax")]
        public double? QuoteSalesTax { get; set; }

        [NotMapped]
        [Display(Name = "Total (ex. Sales Tax)")]
        public double? Total
        {
            get
            {
                return MaterialQuote + SubQuote + LaborQuote;
            }
        }

    }
}
