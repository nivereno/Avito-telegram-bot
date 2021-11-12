using Microsoft.Extensions.Logging;
using Serilog;

namespace AvitoTelegramBot
{
    public class Program
    {
        public static ILoggerFactory Logger { get; private set; }

        static void Main(string[] args) 
        {
            var outputTemplate = "{Timestamp} [{Level}] {Message}{NewLine}{Exception}";
            var logger = new LoggerConfiguration()
                     .MinimumLevel.Information()
                     .WriteTo.File("log.txt",
                                    outputTemplate: outputTemplate,
                                    rollingInterval: RollingInterval.Day,
                                    rollOnFileSizeLimit: true)
                     .CreateLogger();
            Logger = new LoggerFactory();
            Logger.AddSerilog(logger);
        }
    }
}
