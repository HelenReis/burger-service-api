namespace SteakService.Infra
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfigurationSection _configVariables;
        private readonly IConfiguration _config;
        public AppSettings(IConfiguration config)
        {
            _configVariables = config.GetSection("Messages");
            _config = config;
        }
        public string SteakQueue => _configVariables.GetValue<string>("SteakQueue");
        public string RabbitMqHost => _config.GetValue<string>("RABBITMQ_HOST");
        public string ExchangeClient => _configVariables.GetValue<string>("ExchangeClient");
    }
}