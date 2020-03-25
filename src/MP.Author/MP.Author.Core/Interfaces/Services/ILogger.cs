using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Interfaces.Services
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
