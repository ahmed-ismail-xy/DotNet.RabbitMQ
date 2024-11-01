using RabbitMQ.Client;

namespace DotNet.RabbitMQ.Producer.RabbitMQ.Connection;

public class RabbitMqConnection : IRabbitMqConnection, IDisposable
{
    private IConnection? _connection;
    public IConnection Connection => _connection!;

    public bool IsConnected => _connection != null && _connection.IsOpen;


    public RabbitMqConnection()
    {
        _connection = InitializeConnection();
    }

    private IConnection InitializeConnection()
    {
        if (_connection == null || !_connection.IsOpen)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            return factory.CreateConnection();
        }

        return _connection;
    }

    public void Dispose()
    {
        _connection?.Dispose();
    }
}
