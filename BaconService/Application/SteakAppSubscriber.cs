using BaconService.Domain;
using BaconService.Infra;

namespace BaconService.Application
{
    public class BaconAppSubscriber : IBaconAppSubscriber
    {
        private readonly IAppSettings _appSettings;
        private readonly IPublishMessageService _publishServer;
        
        public BaconAppSubscriber(
            IAppSettings appSettings, 
            IPublishMessageService publishServer)
        {
            _appSettings = appSettings;
            _publishServer = publishServer;
        }

        public void SubscribeToMessages()
        {
            var listeningService = new BaconSubscriber(_appSettings, _publishServer);
            listeningService.ListenToMessage();
        }
    }
}