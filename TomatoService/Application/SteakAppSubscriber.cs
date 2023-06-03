using TomatoService.Domain;
using TomatoService.Infra;

namespace TomatoService.Application
{
    public class TomatoAppSubscriber : ITomatoAppSubscriber
    {
        private readonly IAppSettings _appSettings;
        private readonly IPublishMessageService _publishServer;
        
        public TomatoAppSubscriber(
            IAppSettings appSettings, 
            IPublishMessageService publishServer)
        {
            _appSettings = appSettings;
            _publishServer = publishServer;
        }

        public void SubscribeToMessages()
        {
            var listeningService = new TomatoSubscriber(_appSettings, _publishServer);
            listeningService.ListenToMessage();
        }
    }
}