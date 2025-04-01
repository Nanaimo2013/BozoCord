using Serilog;
using Serilog.Events;

namespace BozoCord.Core.Logger
{
    public static class Logger
    {
        private static ILogger? _logger;

        public static ILogger Instance
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .WriteTo.File("logs/bozocord-.txt", 
                            rollingInterval: RollingInterval.Day,
                            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                        .CreateLogger();
                }
                return _logger;
            }
        }
    }
} 