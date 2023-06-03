using LettuceService.Domain;
using LettuceService.Infra;

namespace LettuceService.Application
{
    public class LettuceAppSubscriber : ILettuceAppSubscriber
    {
        private readonly IAppSettings _appSettings;
        private readonly IPublishMessageService _publishServer;
        
        public LettuceAppSubscriber(
            IAppSettings appSettings, 
            IPublishMessageService publishServer)
        {
            _appSettings = appSettings;
            _publishServer = publishServer;
        }

        public void SubscribeToMessages()
        {
            var listeningService = new LettuceSubscriber(_appSettings, _publishServer);
            listeningService.ListenToMessage();
        }
    }
}