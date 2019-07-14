using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace LoanManagement.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanMgmtContext context;

        public LoanRepository(LoanMgmtContext context)
        {
            this.context = context;
        }
        public Loan Add(Loan loan)
        {
            context.Loans.Add(loan);
            context.SaveChanges();
            return loan;
        }

        public Loan Delete(Loan loan)
        {
            Loan _loan = context.Loans.FirstOrDefault(l => l.Id == loan.Id);
            if (_loan != null)
            {
                context.Loans.Remove(_loan);
                context.SaveChanges();
            }
            return _loan;
        }

        public IEnumerable<Loan> GetAllLoans()
        {
            return context.Loans;
        }

        public Loan GetLoan(int Id)
        {
            return context.Loans.FirstOrDefault(l=>l.Id==Id);
        }

        public Loan Update(Loan loanChanges)
        {

            var loan = context.Loans.Attach(loanChanges);
            loan.State = EntityState.Modified;
            context.SaveChanges();
            
            return loanChanges;
        }
    }
}
