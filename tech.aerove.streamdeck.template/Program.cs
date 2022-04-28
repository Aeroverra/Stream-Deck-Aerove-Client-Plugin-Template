using Serilog;
using Tech.Aerove.StreamDeck.Client;
using Tech.Aerove.StreamDeck.Template;

SerilogConfig.Configure();

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog()
    .ConfigureServices((context, services) =>
    {
        //This is how you tell the service container to use the Aerove Client
        services.AddAeroveStreamDeckClient(context);

        //This is where we tell the service container we want
        //to use our Example Service
        services.AddHostedService<ExampleService>();
    })
    .Build();

await host.RunAsync();
