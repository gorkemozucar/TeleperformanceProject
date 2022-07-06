using RabbitMQ.Client;

namespace Application.Business.Abstracts
{
    public interface IRabbitmqConnection
    {
        IConnection GetRabbitMqConnection();
    }
}
