using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanManagement.Domain;
using LoanManagement.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace LoanManagement.Repository
{
    public class UserLoanRepository : BaseRepository<UserLoan>,IUserLoanRepository
    {

        public UserLoanRepository(LoanMgmtContext context):base(context)
        {
            _context = context;
        }

        public LoanMgmtContext _context { get; private set; }

        public override UserLoan Get(int id)
        {
            return _context.UserLoans.Include(u => u.LoanMaster).ToList().Find(u=>u.Id==id);
        }

        public override IEnumerable<UserLoan> GetAll()
        {
            return _context.UserLoans.Include(u => u.LoanMaster).ToList();
        }
    }
}
