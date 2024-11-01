using DotNet.RabbitMQ.Producer.RabbitMQ.Connection;
using System.Text;
using System.Text.Json;

namespace DotNet.RabbitMQ.Producer.RabbitMQ;

public class RabbitMQProducer : IMessageProducer
{
    private readonly IRabbitMqConnection _connection;

    public RabbitMQProducer(IRabbitMqConnection connection)
    {
        _connection = connection;
    }

    public void SendMessage<T>(T message)
    {
        using var channel = _connection.Connection.CreateModel();
        channel.QueueDeclare("message-queue",
                             true,
                             false,
                             false,
                             null);

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        channel.BasicPublish(exchange: "",
                             routingKey: "message-queue",
                             basicProperties: null,
                             body: body,
                             mandatory: true);
    }
}
