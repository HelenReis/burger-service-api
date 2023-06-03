using LettuceService.Infra;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LettuceService.Domain
{
    public class LettuceSubscriber : ILettuceSubscriber
    {
        private readonly IAppSettings _config;
        private readonly IPublishMessageService _publishServer;

        public LettuceSubscriber(
            IAppSettings config, 
            IPublishMessageService publishServer)
        { 
            _publishServer = publishServer;
            _config = config;
        }
        public void ListenToMessage()
        {
            var factory = new ConnectionFactory();
            factory.HostName = _config.RabbitMqHost;
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async(model, ea) =>
            {                
                Console.WriteLine("received message on Lettuce service.");
                _publishServer.PublishMessageToClient();
            };

            channel.BasicConsume(queue: _config.LettuceQueue,
                                     autoAck: true,
                                     consumer: consumer);
        }
    }
}