using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Domain
{
    public class UserLoan:BaseDomainModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserLoanNum { get; set; }

        [Required]
        public double InterestAmount { get; set; }
        [Required]
        public double EarlyPaymentFee { get; set; }
        [Required]
        public double Balance { get; set; }
        public bool AppliedForTopup { get; set; }
        public int LoanMasterId { get; set; }
        public LoanMaster LoanMaster { get; set; }
    }
}
