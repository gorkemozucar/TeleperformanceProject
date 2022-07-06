using Application.Dtos;
using Application.Features.ShoppingLists.Requests.Commands;
using Domain;

namespace Application.Business.Abstracts
{
    public interface IRabbitmqService
    {
        void Publish(ShoppingListUpdateDto list, string exchangeType, string exchangeName, string queueName, string routeKey);
    }
}
