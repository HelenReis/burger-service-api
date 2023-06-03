using LettuceService.Application;
using LettuceService.Domain;
using LettuceService.Infra;

namespace LettuceService
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
            builder.Services.AddScoped<ILettuceAppSubscriber, LettuceAppSubscriber>();
            builder.Services.AddScoped<ILettuceSubscriber, LettuceSubscriber>();
            builder.Services.AddScoped<IPublishMessageService, PublishMessageService>();
            builder.Services.AddScoped<ISetup, Setup>();
        }

        public static void SubscribeToMessages(IServiceProvider serviceProvider) {
            var appSettings = GetServiceScope<IAppSettings>(serviceProvider);
            var publisher = GetServiceScope<IPublishMessageService>(serviceProvider);
            var subscriber = new LettuceAppSubscriber(appSettings, publisher);
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