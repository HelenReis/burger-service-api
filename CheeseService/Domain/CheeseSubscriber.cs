using CheeseService.Infra;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CheeseService.Domain
{
    public class CheeseSubscriber : ICheeseSubscriber
    {
        private readonly IAppSettings _config;
        private readonly IPublishMessageService _publishServer;

        public CheeseSubscriber(
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
                Console.WriteLine("received message on cheese service.");
                _publishServer.PublishMessageToClient();
            };

            channel.BasicConsume(queue: _config.CheeseQueue,
                                     autoAck: true,
                                     consumer: consumer);
        }
    }
}