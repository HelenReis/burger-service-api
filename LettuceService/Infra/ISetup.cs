using RabbitMQ.Client;

namespace LettuceService.Infra
{
    public interface ISetup
    {
        IModel? GetChannel();
    }
}