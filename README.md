# JSlackLog
Log messages to Slack channel

## Usage and registration of the logger

To add JSlack logging provider

1. Add JSlackLogConfig section to appsettings.json:

```json

  "JSlackLogConfig": {
    "webhookUrl": "https://hooks.slack.com/services/{webhook-url}",
  }

```

2. Add JSlackLogger to HostBuilder and configure with the section JSlackConfig

```C#
static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureLogging(builder =>
            builder.ClearProviders()
                .AddJSlackLogger(configuration
                .GetSection("JSlackLogConfig")
                .Get<JSlackLoggerConfiguration>()))
```

