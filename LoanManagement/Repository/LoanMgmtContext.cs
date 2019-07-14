using JetBrains.Annotations;
using LoanManagement.Domain;
using LoanManagement.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Repository
{
    public class LoanMgmtContext : DbContext
    {

        public LoanMgmtContext(DbContextOptions<LoanMgmtContext> options) : base(options)
        {

        }
        public DbSet<LoanMaster> LoanMasters { get; set; }
        public DbSet<UserLoan> UserLoans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var loanList = new List<LoanMaster>(){
                    new LoanMaster() {Id=1, Name = "asd", Type = "Personal", InterestRate = 3.5, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                    new LoanMaster() {Id=2, Name = "dfe", Type = "Personal", InterestRate = 4.5, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                    new LoanMaster() {Id=3, Name = "wer", Type = "Personal", InterestRate = 2.5, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now }
            };


            modelBuilder.Entity<LoanMaster>().HasData(loanList.ToArray());

            var userLoans = new List<UserLoan>() {
                new UserLoan(){Id=1, UserLoanId="678523187", Interest=324,EarlyPaymentFee=67, Payout=1870, AppliedForTopup=false, LoanMasterId=1,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=2, UserLoanId="345785234", Interest=546,EarlyPaymentFee=34, Payout=1902, AppliedForTopup=false, LoanMasterId=1,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=3, UserLoanId="432578456", Interest=233,EarlyPaymentFee=267, Payout=3234, AppliedForTopup=false, LoanMasterId=2,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=4, UserLoanId="245356733", Interest=234,EarlyPaymentFee=464, Payout=4678, AppliedForTopup=false, LoanMasterId=2,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=5, UserLoanId="234677345", Interest=456,EarlyPaymentFee=89, Payout=1647, AppliedForTopup=false, LoanMasterId=1,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=6, UserLoanId="549785345", Interest=343,EarlyPaymentFee=102, Payout=1094, AppliedForTopup=false, LoanMasterId=2,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=7, UserLoanId="456845676", Interest=123,EarlyPaymentFee=98, Payout=2644, AppliedForTopup=false, LoanMasterId=3,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=8, UserLoanId="345689678", Interest=435,EarlyPaymentFee=74, Payout=2355, AppliedForTopup=false, LoanMasterId=3,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=9, UserLoanId="985467845", Interest=265,EarlyPaymentFee=82, Payout=2345, AppliedForTopup=false, LoanMasterId=3,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now }

            };

            modelBuilder.Entity<UserLoan>().HasData(userLoans.ToArray());
        }
    }
}
