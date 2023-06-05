using CookingService.Domain;
using CookingService.Infra;
using CookingService.Shared;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CookingService.Application
{
    public class PublishMessageService : IPublishMessageService
    {
        private readonly IAppSettings _appSettings;
        private readonly ISetup _setup;
        public PublishMessageService(IAppSettings appSettings, ISetup setup) 
        {
            _appSettings = appSettings;
            _setup = setup;
        }

        public void PublishMessage(Ingredients ingredients)
        {
            var ingredientsDictionary = ingredients.ConvertObjectToDictionary();

            foreach (KeyValuePair<string, bool> kvp in ingredientsDictionary)
                PublishIngredient(kvp.Key, kvp.Value);
        }

        public void PublishIngredient(string ingredientName, bool publishIngredient)
        {
            if (publishIngredient is false) 
                return;

            var channel = _setup.GetChannel();
            var consumer = new EventingBasicConsumer(channel);
            channel.BasicPublish(_appSettings.ExchangeCooking, ingredientName);
        }
    }
}