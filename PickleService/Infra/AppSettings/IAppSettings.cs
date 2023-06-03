namespace PickleService.Infra
{
    public interface IAppSettings
    {
        string PickleQueue { get; }
        string RabbitMqHost { get; }
        string ExchangeClient { get; }
    }
}