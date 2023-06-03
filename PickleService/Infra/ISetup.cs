using RabbitMQ.Client;

namespace PickleService.Infra
{
    public interface ISetup
    {
        IModel? GetChannel();
    }
}