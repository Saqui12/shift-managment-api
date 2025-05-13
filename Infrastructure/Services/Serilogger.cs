

using Application.Services.Iterfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class Serilogger<T>(ILogger<T> _log) : IAppLogger<T>
    {
        public void LogError(string message, Exception ex) => _log.LogError(message, ex);
        public void LogInformation(string message) => _log.LogInformation(message);
        public void LogWarning(string message) => _log.LogWarning(message);
    }
}
