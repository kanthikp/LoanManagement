namespace LoanManagement.Helper
{
    public interface IAppLogger
    {
        void LogMessage(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}