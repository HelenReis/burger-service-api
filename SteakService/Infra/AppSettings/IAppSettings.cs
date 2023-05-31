namespace SteakService.Infra
{
    public interface IAppSettings
    {
        string SteakQueue { get; }
        string RabbitMqHost { get; }
        string ExchangeClient { get; }
    }
}