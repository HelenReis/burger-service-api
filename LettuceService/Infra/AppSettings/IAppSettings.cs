namespace LettuceService.Infra
{
    public interface IAppSettings
    {
        string LettuceQueue { get; }
        string RabbitMqHost { get; }
        string ExchangeClient { get; }
    }
}