using Serilog;
using Tech.Aerove.StreamDeck.Client;
using Tech.Aerove.StreamDeck.BeginnerTemplate;

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
