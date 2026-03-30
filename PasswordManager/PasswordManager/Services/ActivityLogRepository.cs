using PasswordManager.Data;
using PasswordManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManager.Services
{
    public class ActivityLogRepository : IActivityLogRepository
    {
        private readonly AppDbContext _context;

        public ActivityLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ActivityLog> GetAllLogs()
        {
            return _context.ActivityLogs.OrderByDescending(a => a._timestamp).ToList();
        }

        public IEnumerable<ActivityLog> GetLogsForUser(string userId)
        {
            return _context.ActivityLogs
                .Where(a => a._userId == userId)
                .OrderByDescending(a => a._timestamp)
                .ToList();
        }

        public void LogActivity(ActivityLog log)
        {
            _context.ActivityLogs.Add(log);
            _context.SaveChanges();
        }
    }
}