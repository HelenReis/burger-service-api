using SteakService.Domain;
using SteakService.Infra;

namespace SteakService.Application
{
    public class SteakAppSubscriber : ISteakAppSubscriber
    {
        private readonly IAppSettings _appSettings;
        private readonly IPublishMessageService _publishServer;
        
        public SteakAppSubscriber(
            IAppSettings appSettings, 
            IPublishMessageService publishServer)
        {
            _appSettings = appSettings;
            _publishServer = publishServer;
        }

        public void SubscribeToMessages()
        {
            var listeningService = new SteakSubscriber(_appSettings, _publishServer);
            listeningService.ListenToMessage();
        }
    }
}