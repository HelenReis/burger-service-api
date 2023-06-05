using TomatoService.Application;
using TomatoService.Domain;
using TomatoService.Infra;

namespace TomatoService
{
    public static class Startup
    {
        public static WebApplication InitializeApp(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            app.MapControllers();
            var serviceProvider = ConfigureScope(app);
            SubscribeToMessages(serviceProvider);
            return app;
        }

        public static void ConfigureServices(WebApplicationBuilder builder) {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IAppSettings, AppSettings>();
            builder.Services.AddScoped<ITomatoAppSubscriber, TomatoAppSubscriber>();
            builder.Services.AddScoped<ITomatoSubscriber, TomatoSubscriber>();
            builder.Services.AddScoped<IPublishMessageService, PublishMessageService>();
            builder.Services.AddScoped<ISetup, Setup>();
        }

        public static void SubscribeToMessages(IServiceProvider serviceProvider) {
            var appSettings = GetServiceScope<IAppSettings>(serviceProvider);
            var publisher = GetServiceScope<IPublishMessageService>(serviceProvider);
            var subscriber = new TomatoAppSubscriber(appSettings, publisher);
            subscriber.SubscribeToMessages();
        }

        public static T GetServiceScope<T>(IServiceProvider serviceProvider) {
            return serviceProvider.GetRequiredService<T>();
        }

        public static IServiceProvider ConfigureScope(WebApplication webHost) {
            var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));
            var scope = serviceScopeFactory.CreateScope();
            var services = scope.ServiceProvider;

            return services;
        }
    }
}