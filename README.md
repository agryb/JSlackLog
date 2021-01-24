# JSlackLog
Log messages to Slack channel

## Usage and registration of the logger

To add JSlack logging provider:

```C#
static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureLogging(builder =>
            builder.ClearProviders()
                .AddJSlackLogger(configuration
                .GetSection("JSlackLogConfig")
                .Get<JSlackLoggerConfiguration>()))
```

``` appsettings.json

  "JSlackLogConfig": {
    "webhookUrl": "https://hooks.slack.com/services/{webhook-url}",
  }

```
