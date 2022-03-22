using NLog;
using BlazerBank.Domain.ILogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerBank.Infrastructure.LoggerManager
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message) => logger.Debug(message);

        public void LogError(string message) => logger.Error(message);

        public void LogInfo(string message) => logger.Info(message);

        public void LogWarn(string message) => logger.Warn(message);
    }
}
