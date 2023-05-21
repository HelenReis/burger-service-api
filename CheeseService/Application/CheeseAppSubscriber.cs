using CheeseService.Domain;
using CheeseService.Infra;

namespace CheeseService.Application
{
    public class CheeseAppSubscriber : ICheeseAppSubscriber
    {
        private readonly IAppSettings _appSettings;
        private readonly IPublishMessageService _publishServer;
        
        public CheeseAppSubscriber(
            IAppSettings appSettings, 
            IPublishMessageService publishServer)
        {
            _appSettings = appSettings;
            _publishServer = publishServer;
        }

        public void SubscribeToMessages()
        {
            var listeningService = new CheeseSubscriber(_appSettings, _publishServer);
            listeningService.ListenToMessage();
        }
    }
}