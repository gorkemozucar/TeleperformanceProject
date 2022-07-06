using System.Text;
using System.Text.Json;
using Application.Business.Abstracts;
using Application.Dtos;
using Application.Features.ShoppingLists.Requests.Commands;
using Domain;
using Microsoft.AspNetCore.Identity;
using RabbitMQ.Client;

namespace Application.Business.Concretes;

//Rabbitmq kuyruk ekleme metodu
public class RabbitmqManager : IRabbitmqService
{
    private readonly IRabbitmqConnection _connection;
    public RabbitmqManager(IRabbitmqConnection connection) => _connection = connection;

    public void Publish(ShoppingListUpdateDto list, string exchangeType, string exchangeName, string queueName, string routeKey)
    {

        using var connection = _connection.GetRabbitMqConnection();
        

        using var channel = connection.CreateModel();

        channel.ExchangeDeclare(exchangeName, exchangeType, false, false);

        channel.QueueDeclare(queueName, false, false, false);

        channel.QueueBind(queueName, exchangeName, routeKey);

        var message = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(list));

        channel.BasicPublish(exchangeName, routeKey, null, message);
    }
}
