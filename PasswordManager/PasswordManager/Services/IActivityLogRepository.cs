using PasswordManager.Models;

namespace PasswordManager.Services
{
    public interface IActivityLogRepository
    {
        IEnumerable<ActivityLog> GetAllLogs();
        IEnumerable<ActivityLog> GetLogsForUser(string userId);
        void LogActivity(ActivityLog log);
    }
}