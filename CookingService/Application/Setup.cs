using CookingService.Infra;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CookingService.Application
{
    public class Setup : ISetup
    {
        private readonly IModel _channel;
        private readonly IAppSettings _appSettings;
        public Setup(IAppSettings appsettings)
        {
            var factory = new ConnectionFactory();
            factory.HostName = appsettings.RabbitMqHost;
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _appSettings = appsettings;
        }

        public void SetupAMQTP()
        {
            _channel.QueueDeclare(_appSettings.BreadQueue, false, false, false);
            _channel.QueueDeclare(_appSettings.CheeseQueue, false, false, false);
            _channel.QueueDeclare(_appSettings.CheeseClient, false, false, false);
            _channel.ExchangeDeclare(_appSettings.ExchangeCooking, _appSettings.TypeExchangeCooking, true, false);
            _channel.QueueBind(_appSettings.BreadQueue, _appSettings.ExchangeCooking, string.Empty);
            _channel.QueueBind(_appSettings.CheeseQueue, _appSettings.ExchangeCooking, string.Empty);
            _channel.ExchangeDeclare(_appSettings.ExchangeClient, _appSettings.TypeExchangeCooking, true, false);
            _channel.QueueBind(_appSettings.CheeseClient, _appSettings.ExchangeClient, string.Empty);
        }

        public IModel? GetChannel() {
            return _channel;
        }
    }
}