using RabbitMQ.Client;

namespace TomatoService.Infra
{
    public interface ISetup
    {
        IModel? GetChannel();
    }
}