using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstone.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        public int ClientTypeId { get; set; }

        public ClientType ClientType { get; set; }

        [Required]
        [StringLength(255)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(5)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(255)]
        public string Comments { get; set; }
    }
}
