namespace CookingService.Infra
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
        public string SteakClient => _configVariables.GetValue<string>("SteakClient");
        public string CheeseQueue => _configVariables.GetValue<string>("CheeseQueue");
        public string CheeseClient => _configVariables.GetValue<string>("CheeseClient");
        public string ExchangeCooking => _configVariables.GetValue<string>("ExchangeCooking");
        public string ExchangeClient => _configVariables.GetValue<string>("ExchangeClient");
        public string TypeExchangeCooking => _configVariables.GetValue<string>("TypeExchangeCooking");
        public string RabbitMqHost => _config.GetValue<string>("RABBITMQ_HOST");
        public string BaconQueue => _configVariables.GetValue<string>("BaconQueue");
        public string BaconClient => _configVariables.GetValue<string>("BaconClient");
        public string LettuceQueue => _configVariables.GetValue<string>("LettuceQueue");
        public string LettuceClient => _configVariables.GetValue<string>("LettuceClient");
        public string PickleQueue => _configVariables.GetValue<string>("PickleQueue");
        public string PickleClient => _configVariables.GetValue<string>("PickleClient");
        public string TomatoQueue => _configVariables.GetValue<string>("TomatoQueue");
        public string TomatoClient => _configVariables.GetValue<string>("TomatoClient");
    }
}