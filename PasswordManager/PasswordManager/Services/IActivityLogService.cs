// ============================================================
// File:    IActivityLogService.cs
// Author:  Eric Bertero
// Purpose: Contract interface for the activity log service.
// ============================================================
using PasswordManager.Models;
using System.Collections.Generic;

namespace PasswordManager.Services
{
    public interface IActivityLogService
    {
        void LogAction(string userId, string action, string ipAddress);
        IEnumerable<ActivityLog> GetRecentLogs();

        Task LogActionAsync(string userId, string action, string ipAddress);
    }
}