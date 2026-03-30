using PasswordManager.Models;
using System.Collections.Generic;

namespace PasswordManager.Services
{
    public interface IActivityLogService
    {
        void LogAction(string userId, string action, string ipAddress);
        IEnumerable<ActivityLog> GetRecentLogs();
    }
}