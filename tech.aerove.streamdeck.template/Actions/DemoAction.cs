using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.aerove.streamdeck.client.Actions;

namespace tech.aerove.streamdeck.template.Actions
{
    /// <summary>
    /// Define what action this class belongs to with the PluginAction
    /// Attribute. Simply pass the UUID as defined in the manifest.json.
    /// If this is not present automapping tries to use the action name
    /// to find the corresponding class.
    /// </summary>
    [PluginAction("tech.aerove.streamdeck.template.demoaction")]

    /// <summary>
    /// This is an example action. Actions must inherit from the ActionBase class.
    /// You can inject any services that were added to the service container.
    /// Actions have a lifetime similar to a singleton service.
    /// </summary>
    public class DemoAction : ActionBase
    {
        private readonly ILogger<DemoAction> _logger;

        /// <summary>
        /// Services are injectable
        /// </summary>
        public DemoAction(ILogger<DemoAction> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// All events are able to be overridden.
        /// You will notice not all information is present in the parameters.
        /// This is because all of our information can be accessed via the context 
        /// </summary>
        public override async Task WillAppearAsync()
        {
            //Accessing the context
            var col = Context.Column;
            var row = Context.Row;
            _logger.LogInformation("My cordinates are Col:{col} Row:{row}", col, row);

            //You can use the Dispatcher to send information to the streamdeck
            await Dispatcher.ShowOkAsync();
        }

        /// <summary>
        /// Even Global events can be received within the action. 
        /// Note: if you are listening to this in multiple instances / actions
        /// all instances will recieve global events at the same time.
        /// </summary>
        public override Task ApplicationDidLaunchAsync(string application)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Optionally you can listen to and send events in a non async fashion
        /// </summary>
        public override void KeyUp(int userDesiredState)
        {
            Dispatcher.ShowOk();
        }

    }
}
