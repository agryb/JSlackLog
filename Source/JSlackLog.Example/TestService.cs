using Microsoft.Extensions.Logging;

namespace JSlackLog.Example
{
    public class TestService
    {
        private readonly ILogger<TestService> _log;

        public TestService(ILogger<TestService> log) 
            => _log = log;

        public void Test() 
            => _log.LogInformation("test slack logging");
    }
}
