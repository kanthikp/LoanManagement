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

        public AppSettingsDataStore AppSettingsDataStore { get; private set; }
        private IAppLogger _appLogger;

        public LoanMgmtContext(
            IAppLogger appLogger,
            IOptions<AppSettingsDataStore> appSettingsDataStore)
        {
            _appLogger = appLogger;
            AppSettingsDataStore = appSettingsDataStore.Value;
        }

        public LoanMgmtContext(
            IAppLogger appLogger,
            AppSettingsDataStore appSettings)
        {
            _appLogger = appLogger;
            AppSettingsDataStore = appSettings;
        }

        //public LoanMgmtContext(DbContextOptions<LoanMgmtContext> options) : base(options)
        //{

        //}
        public DbSet<LoanMaster> LoanMasters { get; set; }
        public DbSet<UserLoan> UserLoans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var loanList = new List<LoanMaster>(){
                    new LoanMaster() {Id=1, Name = "Temporibus autem", Type = "Personal", InterestRate = 3.5, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                    new LoanMaster() {Id=2, Name = "Placeat facere", Type = "Personal", InterestRate = 4.5, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                    new LoanMaster() {Id=3, Name = "Dolorem ipsum quia", Type = "Personal", InterestRate = 2.5, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                    new LoanMaster() {Id=4, Name = "Reprehenderit qui", Type = "Personal", InterestRate = 2.5, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now }

            };


            modelBuilder.Entity<LoanMaster>().HasData(loanList.ToArray());

            var userLoans = new List<UserLoan>() {
                new UserLoan(){Id=1,UserId=1, UserLoanNum="678523187", InterestAmount=324,EarlyPaymentFee=67, Balance=1870, AppliedForTopup=false, LoanMasterId=1,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=2,UserId=2, UserLoanNum="345785234", InterestAmount=546,EarlyPaymentFee=34, Balance=1902, AppliedForTopup=false, LoanMasterId=1,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=3,UserId=2, UserLoanNum="432578456", InterestAmount=233,EarlyPaymentFee=267, Balance=3234, AppliedForTopup=false, LoanMasterId=2,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=4,UserId=3, UserLoanNum="245356733", InterestAmount=234,EarlyPaymentFee=464, Balance=4678, AppliedForTopup=false, LoanMasterId=2,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=5,UserId=3, UserLoanNum="234677345", InterestAmount=456,EarlyPaymentFee=89, Balance=1647, AppliedForTopup=false, LoanMasterId=1,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=6,UserId=3, UserLoanNum="549785345", InterestAmount=343,EarlyPaymentFee=102, Balance=1094, AppliedForTopup=false, LoanMasterId=3,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=7,UserId=4, UserLoanNum="456845676", InterestAmount=123,EarlyPaymentFee=98, Balance=2644, AppliedForTopup=false, LoanMasterId=1,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=8,UserId=4, UserLoanNum="345689678", InterestAmount=435,EarlyPaymentFee=74, Balance=2355, AppliedForTopup=false, LoanMasterId=2,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=9,UserId=4, UserLoanNum="985467845", InterestAmount=265,EarlyPaymentFee=82, Balance=2345, AppliedForTopup=false, LoanMasterId=3,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new UserLoan(){Id=10,UserId=4, UserLoanNum="985435846", InterestAmount=265,EarlyPaymentFee=82, Balance=2345, AppliedForTopup=false, LoanMasterId=4,CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now }

            };

            modelBuilder.Entity<UserLoan>().HasData(userLoans.ToArray());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _appLogger.LogError(message: $"DataStore Type: '{AppSettingsDataStore.Type}', ConnectionString: '{AppSettingsDataStore.ConnectionString}'");
            switch (AppSettingsDataStore.Type)
            {
                case "InMemoryDatabase":
                    optionsBuilder.UseInMemoryDatabase(AppSettingsDataStore.Name, null);
                    break;
                case "Sqlite":
                    optionsBuilder.UseSqlite(AppSettingsDataStore.ConnectionString);
                    break;
                case "SqlServer":
                    optionsBuilder.UseSqlServer(AppSettingsDataStore.ConnectionString);
                    break;
                default:
                    _appLogger.LogError(message: $"PenMgmtContext::OnConfiguring() >> Invalid DataStore Type '{AppSettingsDataStore.Type}' configured. NOT SUPPORTED.");
                    // TODO: Throw error and exit
                    break;
            }
        }
    }
}
