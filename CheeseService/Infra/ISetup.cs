using RabbitMQ.Client;

namespace CheeseService.Infra
{
    public interface ISetup
    {
        IModel? GetChannel();
    }
}