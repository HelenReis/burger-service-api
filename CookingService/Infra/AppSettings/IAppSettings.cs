namespace CookingService.Infra
{
    public interface IAppSettings
    {
        string SteakQueue { get; }
        string SteakClient { get; }
        string CheeseQueue { get; }
        string CheeseClient { get; }
        string BaconQueue { get; }
        string BaconClient { get; }
        string LettuceQueue { get; }
        string LettuceClient { get; }
        string PickleQueue { get; }
        string PickleClient { get; }
        string TomatoQueue { get; }
        string TomatoClient { get; }
        string ExchangeCooking { get; }
        string ExchangeClient { get; }
        string TypeExchangeCooking { get; }
        string RabbitMqHost { get; }
    }
}