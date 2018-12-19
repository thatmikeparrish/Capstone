﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Project Number")]
        public string ProjectNumber { get; set; }

        [Display(Name = "Work Day")]
        public int WorkDay { get; set; }

        public double? SalesTax { get; set; }

        [Display(Name = "Sales Tax")]
        public double? ProjectSalesTax
        {
            get
            {
                return SalesTax / 100;
            }
        }

        [Display(Name = "Unburdened Rate")]
        public double? UnburdenedRate { get; set; }

        [Display(Name = "Labor Margin")]
        public double? LaborMargin { get; set; }

        public int? TotalId { get; set; }

        public int? WorkforceCalcId { get; set; }

        public WorkforceCalc WorkforceCalc { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Completion Date")]
        public DateTime? CompletionDate { get; set; }

        [Display(Name = "Complete?")]
        public bool? IsCompleted { get; set; }

        public int? TimeTrackerId { get; set; }

        [Display(Name = "Total Material Cost")]
        public double? TotalMaterialCost { get; set; }

        [Display(Name = "Material Margin")]
        public double? TotalMaterialMargin
        {
            get
            {
                return 1 - (TotalMaterialCost / TotalMaterialQuote);
            }
        }

        [Display(Name = "Total Material Quote")]
        public double? TotalMaterialQuote { get; set; }

        [Display(Name = "Total Subcontract Cost")]
        public double? TotalSubCost { get; set; }

        [Display(Name = "Total Subcontract Margin")]
        public double? TotalSubMargin
        {
            get
            {
                return 1 - (TotalSubCost / TotalSubQuote);
            }
        }

        [Display(Name = "Total Subcontract Quote")]
        public double? TotalSubQuote { get; set; }

        [Display(Name = "Total ManHours")]
        public double? TotalManHours { get; set; }

        [Display(Name = "Total Labor Cost")]
        public double? TotalLaborCost
        {
            get
            {
                return TotalManHours * UnburdenedRate;
            }
        }

        [Display(Name = "Total Labor Quote")]
        public double? TotalLaborQuote
        {
            get
            {
                return TotalLaborCost * (1 + LaborMargin);
            }
        }

        [Display(Name = "Total Sales Tax")]
        public double? TotalSalesTax
        {
            get
            {
                return TotalMaterialQuote * LaborMargin;
            }
        }

        [Display(Name = "Quote Value")]
        public double? GrandTotal
        {
            get
            {
                return TotalMaterialQuote + TotalSalesTax + TotalSubQuote + TotalLaborQuote;
            }
        }

        public virtual ICollection<LineItem> LineItems { get; set;}

        public virtual ICollection<WorkforceCalc> WorkforceCalcs { get; set;}
    }
}
