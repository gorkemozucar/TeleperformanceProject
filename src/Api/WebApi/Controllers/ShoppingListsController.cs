using Application.Features.ShoppingLists.Requests.Commands;
using Application.Features.ShoppingLists.Requests.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShoppingList(UpdateShoppingListCommand request)
        {
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoppingList(CreateShoppingListCommand request)
        {
            var result = await _mediator.Send(request);

            if (result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else if (result.StatusCode == 401)
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingListItem(DeleteShoppingListCommand request)
        {
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingListById(string id)
        {
            var request = new GetShoppingListByIdQuery(id);
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShoppingLists(int pageNumber, int pageSize, string? CategoryName,DateTime CreatedDate, DateTime CompletedDate)
        {
            var request = new GetAllShoppingListQuery(pageNumber, pageSize, CategoryName, CreatedDate, CompletedDate);
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

    }
}
