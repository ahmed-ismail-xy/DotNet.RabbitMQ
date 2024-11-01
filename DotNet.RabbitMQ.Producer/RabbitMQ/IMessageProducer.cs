namespace DotNet.RabbitMQ.Producer.RabbitMQ;

public interface IMessageProducer
{
    void SendMessage<T>(T message);
}
