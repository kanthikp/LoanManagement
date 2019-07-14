using LoanManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Repository
{
    public class MockLoanRepository:ILoanRepository
    {
        private List<Loan> _loanList;
        public void LoanRepository()
        {
            _loanList = new List<Loan>()
            {
                new Loan(){Id=1,Name="asd",Type="Personal", InterestRate=3.5,CreatedOn=DateTime.Now,UpdatedOn=DateTime.Now},

                new Loan(){Id=2,Name="dfe",Type="Personal", InterestRate=4.5,CreatedOn=DateTime.Now,UpdatedOn=DateTime.Now},

                new Loan(){Id=3,Name="wer",Type="Personal", InterestRate=2.5,CreatedOn=DateTime.Now,UpdatedOn=DateTime.Now}
            };
        }

        public Loan Add(Loan loan)
        {
            loan.Id = _loanList.Max(l => l.Id) + 1;
            _loanList.Add(loan);
            return loan;
        }

        public Loan Delete(Loan loan)
        {
            Loan _loan = _loanList.FirstOrDefault(l => l.Id == loan.Id);
            if (_loan != null)
            {
                _loanList.Remove(_loan);
            }

            return loan;
        }

        public IEnumerable<Loan> GetAllLoans()
        {
            return _loanList;
        }

        public Loan GetLoan(int Id)
        {
            return _loanList.FirstOrDefault(l => l.Id == Id);
        }

        public Loan Update(Loan loanChanges)
        {

            Loan loan = _loanList.FirstOrDefault(l => l.Id == loanChanges.Id);
            if (loan != null)
            {
                loan.Name = loanChanges.Name;
                loan.Type = loanChanges.Name;
                loan.InterestRate = loanChanges.InterestRate;
                loan.UpdatedOn = DateTime.Now;
            }

            return loan;
        }
    }


}
