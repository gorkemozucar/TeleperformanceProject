using Application.Dtos;
using Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ShoppingListItems.Requests.Commands
{
    public record CreateShoppingListItemCommand(string Name, string StockUnitName, int Amount) : IRequest<ServiceResponse<ShoppingListItemDto>>;
}
