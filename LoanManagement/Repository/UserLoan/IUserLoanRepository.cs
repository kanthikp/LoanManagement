﻿using LoanManagement.Domain;
using LoanManagement.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Repository
{
    public interface IUserLoanRepository:IBaseRepository<UserLoan>
    {
        IEnumerable<UserLoan> GetByUserId(int userId);
        UserLoan GetByLoanIdUserId(int id, int userId);

    }
}
