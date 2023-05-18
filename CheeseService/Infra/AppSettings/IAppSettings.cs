namespace CheeseService.Infra
{
    public interface IAppSettings
    {
        string CheeseQueue { get; }
        string RabbitMqHost { get; }
        string ExchangeClient { get; }
    }
}