using Application.Dtos;
using Application.Wrapper;
using MediatR;

namespace Application.Features.ShoppingLists.Requests.Commands
{
    public record UpdateShoppingListCommand(string Id, string Name,string CategoryName,string note , bool IsCompleted) : IRequest<ServiceResponse<ShoppingListUpdateDto>>;
}
