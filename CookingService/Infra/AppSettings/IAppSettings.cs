namespace CookingService.Infra
{
    public interface IAppSettings
    {
        string CheeseQueue { get; }
        string CheeseClient { get; }
        string BreadQueue { get; }
        string ExchangeCooking { get; }
        string ExchangeClient { get; }
        string TypeExchangeCooking { get; }
        string RabbitMqHost { get; }
    }
}