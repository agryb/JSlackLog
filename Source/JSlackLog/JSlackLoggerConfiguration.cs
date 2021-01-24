using Microsoft.Extensions.Logging;

namespace JSlackLog
{
    public class JSlackLoggerConfiguration
    {
        public int EventId { get; set; }
        public LogLevel LogLevel { get; set; } = LogLevel.Information;

        /// <summary>
        /// Slack logging requires http request to Slack webhook endpoint.
        /// False: each log call will wait (synchroniously) for slack web response
        /// True: web request sent, execution continues without waiting for response (fire and forget)
        /// WARNING: IN CASE OF FIRE&FORGET SOME LOG MESSAGES COULD BE LOST
        /// </summary>
        public bool FireAndForget { get; set; } = false;

        /// <summary>
        /// Slack webhook url
        /// </summary>
        public string WebhookUrl { get; set; }
    }
}
