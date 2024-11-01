using DotNet.RabbitMQ.Producer.RabbitMQ;
using DotNet.RabbitMQ.Producer.RabbitMQ.Connection;

namespace DotNet.RabbitMQ.Producer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();
        builder.Services.AddScoped<IMessageProducer, RabbitMQProducer>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
