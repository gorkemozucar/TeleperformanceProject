using Application.Business.Abstracts;
using RabbitMQ.Client;

namespace Application.Business.Concretes
{
    public class RabbitmqConnection : IRabbitmqConnection
    {
        public IConnection GetRabbitMqConnection()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                VirtualHost = "/",
                Port = 5672,
                UserName = "guest",
                Password = "guest"

            }.CreateConnection();

            return connectionFactory;
        }
    }
}
