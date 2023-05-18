using CheeseService.Infra;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CheeseService.Domain
{
    public class PublishMessageService : IPublishMessageService
    {
        private readonly IAppSettings _appSettings;
        private readonly ISetup _setup;
        public PublishMessageService(IAppSettings appSettings, ISetup setup) 
        {
            _appSettings = appSettings;
            _setup = setup;
        }

        public void PublishMessageToClient()
        {
            var channel = _setup.GetChannel();
            var consumer = new EventingBasicConsumer(channel);

            channel.BasicPublish(_appSettings.ExchangeClient, string.Empty);
        }
    }
}