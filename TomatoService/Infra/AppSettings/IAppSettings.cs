namespace TomatoService.Infra
{
    public interface IAppSettings
    {
        string TomatoQueue { get; }
        string RabbitMqHost { get; }
        string ExchangeClient { get; }
    }
}