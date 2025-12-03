using Serilog;

namespace Tech.Aerove.StreamDeck.Template
{
    internal class SerilogConfig
    {
        public static void Configure()
        {
            string ConsoleFormat = "[{Timestamp:HH:mm:ss} {Level:u3}] [{SourceContext:l}] {Message:lj}{NewLine}{Exception}";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
