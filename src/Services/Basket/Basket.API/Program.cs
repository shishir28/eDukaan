using Basket.API.GrpcServices;
using Basket.API.Mapper;
using Basket.API.Repositories;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

//Redis configuration
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
});


builder.Services.AddControllers();
builder.Services.AddGrpcClient<Discount.Grpc.Protos.DiscountProtoService.DiscountProtoServiceClient>(options =>
{
    options.Address = new Uri(configuration.GetValue<string>("GrpcSettings:DiscountUrl"));
});
builder.Services.AddScoped<DiscountGrpcService>();

//MassTransit Config
builder.Services.AddMassTransit(congfig =>
{
    congfig.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(new Uri(configuration.GetValue<string>("RabbitMqSettings:Host")), hostConfigurator =>
        {
            hostConfigurator.Username(configuration.GetValue<string>("RabbitMqSettings:Username"));
            hostConfigurator.Password(configuration.GetValue<string>("RabbitMqSettings:Password"));
        });
    });
});

builder.Services.AddMassTransitHostedService();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Basket.API", Version = "v1" });
});

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddAutoMapper(typeof(BasketProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket.API v1"));

}

app.UseAuthorization();

app.MapControllers();

app.Run();
