using LoanManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Repository
{
    public interface ILoanRepository
    {
        Loan GetLoan(int Id);
        IEnumerable<Loan> GetAllLoans();
        Loan Add(Loan loan);
        Loan Update(Loan loanChanges);
        Loan Delete(Loan loan);

    }
}
