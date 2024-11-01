using RabbitMQ.Client;

namespace DotNet.RabbitMQ.Producer.RabbitMQ.Connection;

public interface IRabbitMqConnection
{
    IConnection Connection { get; }

    bool IsConnected { get; }
}
