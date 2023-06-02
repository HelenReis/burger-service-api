namespace BaconService.Infra
{
    public interface IAppSettings
    {
        string BaconQueue { get; }
        string RabbitMqHost { get; }
        string ExchangeClient { get; }
    }
}