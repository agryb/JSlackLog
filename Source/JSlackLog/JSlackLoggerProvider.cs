using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace JSlackLog
{
    public class JSlackLoggerProvider : ILoggerProvider
    {
        private readonly JSlackLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, JSlackLogger> _loggers 
            = new ConcurrentDictionary<string, JSlackLogger>();

        public JSlackLoggerProvider(JSlackLoggerConfiguration config) 
            => _config = config;

        public ILogger CreateLogger(string categoryName) 
            => _loggers.GetOrAdd(categoryName, name => new JSlackLogger(name, _config));

        public void Dispose() => _loggers.Clear();
    }
}
