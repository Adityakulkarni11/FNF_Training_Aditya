using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetFrameworkLib.Utils
{
    internal static class Logger
    {
        
        private static string logFile = string.Empty;
        private static void Initialize()
        {
            string executingDir=AppDomain.CurrentDomain.BaseDirectory;
            string fileName=$"Log_{DateTime.Now:yyyyMMdd}.txt";
            string filePath=Path.Combine(executingDir, fileName);
            logFile = filePath;
        }

        public static void LogInformation(string message)
        {
            if (string.IsNullOrEmpty(logFile))
            {
                Initialize();
            }

            message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - INFO - {message}";
            File.WriteAllText(logFile, message);
        }
    }
}
