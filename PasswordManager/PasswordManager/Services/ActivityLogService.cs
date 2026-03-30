using PasswordManager.Models;
using System.Collections.Generic;

namespace PasswordManager.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IActivityLogRepository _repo;

        public ActivityLogService(IActivityLogRepository repo)
        {
            _repo = repo;
        }

        public void LogAction(string userId, string action, string ipAddress)
        {
            var log = new ActivityLog
            {
                _userId = userId,
                _action = action,
                _ipAddress = ipAddress
            };
            _repo.LogActivity(log);
        }

        public IEnumerable<ActivityLog> GetRecentLogs()
        {
            return _repo.GetAllLogs();
        }
    }
}