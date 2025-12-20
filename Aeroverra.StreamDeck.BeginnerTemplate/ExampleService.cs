using Aeroverra.StreamDeck.Client;
using Aeroverra.StreamDeck.Client.Events;


namespace Aeroverra.StreamDeck.BeginnerTemplate
{
    /// <summary>
    /// This example service shows how you can subscribe to all events outside of the
    /// actions themselves
    /// </summary>
    public class ExampleService : BackgroundService
    {
        private readonly ILogger<ExampleService> _logger;
        private readonly EventManager _eventsManager;
        private readonly IElgatoDispatcher _elgatoDispatcher;

        /// <summary>
        /// Simply put the EventManager and IElgatoDispatcher in the constructor and
        /// the sevice provider will inject an instance when the application starts. 
        /// You can then subscribe like any other C# event.
        /// </summary>
        public ExampleService(ILogger<ExampleService> logger, EventManager eventsManager, IElgatoDispatcher dispatcher)
        {
            _logger = logger;
            _eventsManager = eventsManager;
            _elgatoDispatcher = dispatcher;

            //this is how you subscribe to events;
            eventsManager.OnKeyUp += HandleKeyUp;
            eventsManager.OnDidReceiveSettings += DidReceiveSettings;
            eventsManager.OnDidReceiveGlobalSettings += DidReceiveGlobalSettings;
        }

        /// <summary>
        /// This is called after the service is started 
        /// </summary>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //we can loop forever and perform operations or just let the task return
            //and only use the event handlers
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
            }
        }

        /// <summary>
        /// This is an event handler that will recieve all key up events.
        /// </summary>
        public void HandleKeyUp(object? sender, KeyUpEvent e)
        {
            _logger.LogInformation("ExampleService Received event {event}", e.Event);
        }

        /// <summary>
        /// This is an event handler that will recieve all incoming settings events
        /// </summary>
        public void DidReceiveSettings(object? sender, DidReceiveSettingsEvent e)
        {
            _logger.LogInformation("ExampleService Received event {event}", e.Event);

            //because these events cover all instances you will need to extract the info
            //yourself and specify any info needed to dispatch to the stream deck
            _elgatoDispatcher.ShowOk(e.Context);
        }

        /// <summary>
        /// This is an event handler that will recieve all incoming global settings events
        /// </summary>
        public void DidReceiveGlobalSettings(object? sender, DidReceiveGlobalSettingsEvent e)
        {
            _logger.LogInformation("ExampleService Received event {event}", e.Event);
        }

    }
}