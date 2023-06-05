using RabbitMQ.Client;

namespace TomatoService.Infra
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

        public IModel? GetChannel() {
            return _channel;
        }
    }
}