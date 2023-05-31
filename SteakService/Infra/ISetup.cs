using RabbitMQ.Client;

namespace SteakService.Infra
{
    public interface ISetup
    {
        IModel? GetChannel();
    }
}