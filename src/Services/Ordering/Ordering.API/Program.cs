using EventBus.Messages.Common;
using MassTransit;
using Ordering.API.EventBusConsumer;
using Ordering.API.Mappings;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ApplicationService();

//MassTransit Config
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<BasketCheckoutConsumer>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(new Uri(configuration.GetValue<string>("EventBusSettings:Host")), hostConfigurator =>
        {
            hostConfigurator.Username(configuration.GetValue<string>("EventBusSettings:Username"));
            hostConfigurator.Password(configuration.GetValue<string>("EventBusSettings:Password"));
        });
        cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, e =>
        {
            e.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
        });
    });
});
builder.Services.AddAutoMapper(typeof(OrderingProfile));
builder.Services.AddScoped<BasketCheckoutConsumer>();

builder.Services.AddMassTransitHostedService();

builder.Services.AddInfrastructureServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Ordering.API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordering.API v1"));
}

app.Services.MigrateDB();

app.UseAuthorization();

app.MapControllers();

app.Run();
