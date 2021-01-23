using System;
using Microsoft.Extensions.Logging;

namespace JSlackLog
{
    public static class JSlackLoggerExtensions
    {
        public static ILoggingBuilder AddJSlackLogger(this ILoggingBuilder builder) 
            => builder.AddJSlackLogger(new JSlackLoggerConfiguration());

        public static ILoggingBuilder AddJSlackLogger(
            this ILoggingBuilder builder,
            Action<JSlackLoggerConfiguration> configure)
        {
            var config = new JSlackLoggerConfiguration();
            configure(config);
            return builder.AddJSlackLogger(config);
        }

        public static ILoggingBuilder AddJSlackLogger(
            this ILoggingBuilder builder,
            JSlackLoggerConfiguration config)
        {
            builder.AddProvider(new JSlackLoggerProvider(config));
            return builder;
        }
    }
}
