# JSlackLog
Log messages to Slack channel

## Usage and registration of the logger

To add JSlack logging provider, add an ILoggerProvider with IloggingBuilder as following:

```C#
static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureLogging(builder =>
            builder.ClearProviders()
                .AddProvider(
                    new JSlackLoggerProvider(
                        new JSlackLoggerConfiguration
                        {
                            LogLevel = LogLevel.Error,
                            WebhookUrl = "<slack-webhook-url>"
                        }))
                .AddJSlackLogger()
                .AddJSlackLogger(configuration =>
                {
                    configuration.LogLevel = LogLevel.Warning;
                    configuration.WebhookUrl = "<slack-webhook-url>";
                }));
```
