using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanManagement.Domain;
using LoanManagement.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace LoanManagement.Repository
{
    public class LoanMasterRepository : BaseRepository<LoanMaster>,ILoanMasterRepository
    {

        public LoanMasterRepository(LoanMgmtContext context):base(context)
        {

        }
        
    }
}
