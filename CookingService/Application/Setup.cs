using CookingService.Infra;
using RabbitMQ.Client;

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
            _channel.QueueDeclare(_appSettings.BaconQueue, false, false, false);
            _channel.QueueDeclare(_appSettings.CheeseQueue, false, false, false);
            _channel.QueueDeclare(_appSettings.SteakQueue, false, false, false);
            _channel.QueueDeclare(_appSettings.LettuceQueue, false, false, false);
            _channel.QueueDeclare(_appSettings.PickleQueue, false, false, false);
            _channel.QueueDeclare(_appSettings.TomatoQueue, false, false, false);
            _channel.ExchangeDeclare(_appSettings.ExchangeCooking, "direct", true, false);
            _channel.QueueBind(_appSettings.BaconQueue, _appSettings.ExchangeCooking, "bacon");
            _channel.QueueBind(_appSettings.CheeseQueue, _appSettings.ExchangeCooking, "cheese");
            _channel.QueueBind(_appSettings.SteakQueue, _appSettings.ExchangeCooking, "steak");
            _channel.QueueBind(_appSettings.LettuceQueue, _appSettings.ExchangeCooking, "lettuce");
            _channel.QueueBind(_appSettings.PickleQueue, _appSettings.ExchangeCooking, "pickle");
            _channel.QueueBind(_appSettings.TomatoQueue, _appSettings.ExchangeCooking, "tomato");

            _channel.QueueDeclare(_appSettings.CheeseClient, false, false, false);
            _channel.QueueDeclare(_appSettings.SteakClient, false, false, false);
            _channel.QueueDeclare(_appSettings.BaconClient, false, false, false);
            _channel.QueueDeclare(_appSettings.LettuceClient, false, false, false);
            _channel.QueueDeclare(_appSettings.TomatoClient, false, false, false);
            _channel.QueueDeclare(_appSettings.PickleClient, false, false, false);
            _channel.ExchangeDeclare(_appSettings.ExchangeClient, "direct", true, false);
            _channel.QueueBind(_appSettings.CheeseClient, _appSettings.ExchangeClient, "cheese");
            _channel.QueueBind(_appSettings.SteakClient, _appSettings.ExchangeClient, "steak");
            _channel.QueueBind(_appSettings.BaconClient, _appSettings.ExchangeClient, "bacon");
            _channel.QueueBind(_appSettings.TomatoClient, _appSettings.ExchangeClient, "tomato");
            _channel.QueueBind(_appSettings.LettuceClient, _appSettings.ExchangeClient, "lettuce");
            _channel.QueueBind(_appSettings.PickleClient, _appSettings.ExchangeClient, "pickle");
        }

        public IModel? GetChannel() {
            return _channel;
        }
    }
}