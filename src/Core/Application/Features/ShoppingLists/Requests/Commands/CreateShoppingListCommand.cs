using Application.Dtos;
using Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ShoppingLists.Requests.Commands
{
    public record CreateShoppingListCommand(string Name, string CategoryName , string Note ) : IRequest<ServiceResponse<ShoppingListDto>>;
}
