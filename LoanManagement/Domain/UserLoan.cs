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
        public string UserLoanId { get; set; }

        [Required]
        public double Interest { get; set; }
        [Required]
        public double EarlyPaymentFee { get; set; }
        [Required]
        public double Payout { get; set; }
        public bool AppliedForTopup { get; set; }
        public int LoanMasterId { get; set; }
        public LoanMaster LoanMaster { get; set; }
    }
}
