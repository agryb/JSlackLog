using Microsoft.Extensions.Logging;

namespace JSlackLog
{
    public class JSlackLoggerConfiguration
    {
        public int EventId { get; set; }
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
        public string WebhookUrl { get; set; }
    }
}
