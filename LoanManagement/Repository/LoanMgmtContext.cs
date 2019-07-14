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
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var loanList = new List<Loan>(){
                    new Loan() {Id=1, Name = "asd", Type = "Personal", InterestRate = 3.5, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                    new Loan() {Id=2, Name = "dfe", Type = "Personal", InterestRate = 4.5, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                    new Loan() {Id=3, Name = "wer", Type = "Personal", InterestRate = 2.5, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now }
            };


            modelBuilder.Entity<Loan>().HasData(loanList.ToArray());
        }
    }
}
