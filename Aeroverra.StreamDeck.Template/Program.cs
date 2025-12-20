using Serilog;
using Aeroverra.StreamDeck.Client;
using Aeroverra.StreamDeck.Template;

SerilogConfig.Configure();

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog()
    .ConfigureServices((context, services) =>
    {
        services.AddAeroveStreamDeckClient(context);
        services.AddHostedService<ExampleService>();
    })
    .Build();

await host.RunAsync();
