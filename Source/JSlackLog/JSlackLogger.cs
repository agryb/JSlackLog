using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace JSlackLog
{
    public class JSlackLogger : ILogger
    {
        private readonly string _name;
        private readonly JSlackLoggerConfiguration _config;

        public JSlackLogger(string name, JSlackLoggerConfiguration config) 
            => (_name, _config) = (name, config);

        public IDisposable BeginScope<TState>(TState state) 
            => default;

        public bool IsEnabled(LogLevel logLevel) 
            => logLevel == _config.LogLevel;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            if (_config.EventId != 0 && _config.EventId != eventId.Id) 
                return;


            var text = $"{_name} - {formatter(state, exception)}";
            var json = JsonConvert.SerializeObject(new {text});
            var task = Task.Run(
                async () =>
                {
                    using var httpClient = new HttpClient();
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    var r = await httpClient.PostAsync(_config.WebhookUrl, stringContent);
                    await r.Content.ReadAsStringAsync();
                });
            task.Wait();
        }
    }
}
