using PickleService.Domain;
using PickleService.Infra;

namespace PickleService.Application
{
    public class PickleAppSubscriber : IPickleAppSubscriber
    {
        private readonly IAppSettings _appSettings;
        private readonly IPublishMessageService _publishServer;
        
        public PickleAppSubscriber(
            IAppSettings appSettings, 
            IPublishMessageService publishServer)
        {
            _appSettings = appSettings;
            _publishServer = publishServer;
        }

        public void SubscribeToMessages()
        {
            var listeningService = new PickleSubscriber(_appSettings, _publishServer);
            listeningService.ListenToMessage();
        }
    }
}