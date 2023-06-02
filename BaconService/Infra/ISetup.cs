using RabbitMQ.Client;

namespace BaconService.Infra
{
    public interface ISetup
    {
        IModel? GetChannel();
    }
}