using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Helper
{
    public class AppLogger : IAppLogger
    {
        public void LogMessage(string message)
        {
            LogMessageInternal(message);
        }

        public void LogWarning(string message)
        {
            LogMessageInternal(message);

        }
        public void LogError(string message)
        {
            LogMessageInternal(message);
        }

        private void LogMessageInternal(string message)
        {
            Console.WriteLine(message);
        }
    }
}
