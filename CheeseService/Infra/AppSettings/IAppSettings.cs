namespace CheeseService.Infra
{
    public interface IAppSettings
    {
        string CheeseQueue { get; }
        string CheeseClient { get; }
        string RabbitMqHost { get; }
        string ExchangeCooking { get; }
        string ExchangeClient { get; }
        string TypeExchangeCooking { get; }
    }
}