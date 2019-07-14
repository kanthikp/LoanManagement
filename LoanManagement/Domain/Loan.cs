using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Domain
{
    public class Loan:BaseDomainModel
    {
        // Important Properties - Can be set only during object creation 
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }

        // Object Properties - Can be updated during the lifetime of object
        public double InterestRate { get; set; }
    }
}
