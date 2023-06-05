using CookingService.Application;
using CookingService.Infra;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ISetup, Setup>();
builder.Services.AddScoped<IPublishMessageService, PublishMessageService>();
builder.Services.AddScoped<IAppSettings, AppSettings>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Burger Service",
        Description = "Demonstration of how to utilize event-driven architecture. In a burger.",
        Contact = new OpenApiContact
        {
            Name = "Helen Reis",
            Url = new Uri("https://www.linkedin.com/in/helenreis15/")
        }
    });
});

var app = builder.Build();

var serviceProvider = ConfigureScope(app);
SendMessages(serviceProvider);

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void SendMessages(IServiceProvider serviceProvider) {
    var appSettings = GetServiceScope<IAppSettings>(serviceProvider);
    var setup = new Setup(appSettings);
    setup.SetupAMQTP();
}

static T GetServiceScope<T>(IServiceProvider serviceProvider) {
    return serviceProvider.GetRequiredService<T>();
}

static IServiceProvider ConfigureScope(WebApplication webHost) {
    var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));
    var scope = serviceScopeFactory.CreateScope();
    var services = scope.ServiceProvider;

    return services;
}
