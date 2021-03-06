﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class EmployeeType
    {
        [Key]
        public int EmployeeTypeId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Category")]
        public string Category { get; set; }
    }
}
