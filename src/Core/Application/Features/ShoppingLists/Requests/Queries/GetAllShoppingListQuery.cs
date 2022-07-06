using Application.Dtos;
using Application.Wrapper;
using MediatR;

namespace Application.Features.ShoppingLists.Requests.Queries
{
    public record GetAllShoppingListQuery(int PageNumber,int PageSize,string CategoryName, DateTime CreatedDate , DateTime CompletedDate) : IRequest<ServiceResponse<IEnumerable<ShoppingListDto>>>;
}
