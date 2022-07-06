using Application.Business.Abstracts;
using Application.Contracts.Cache;
using Application.Dtos;
using Application.Features.ShoppingLists.Requests.Commands;
using Application.Features.ShoppingLists.Requests.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICacheManager _cacheManager;
        //private readonly IRabbitmqService _rabbitmqManager;


        public ShoppingListsController(IMediator mediator, ICacheManager cacheManager)
        {
            _mediator = mediator;
            _cacheManager = cacheManager;

            //_rabbitmqManager = rabbitmqManager;
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
            else if (result.StatusCode == 500)
            {
                return BadRequest();
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
            if (_cacheManager.IsAdd(id))
            {
                var data = _cacheManager.Get(id);
                return Ok(data);
            }

            var request = new GetShoppingListByIdQuery(id);
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
                return NotFound(result);
            _cacheManager.Add(id, result, 15);
            return Ok(result);
        }


        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllShoppingLists(int pageNumber, int pageSize, string keyword)
        {
            var request = new GetAllShoppingListQuery(pageNumber, pageSize, keyword);
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpPut("IsComplete")]
        public async Task<IActionResult> CompleteShoppingList(ShoppingListCompletedCommand request)
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
            else if (result.StatusCode == 500)
            {
                return BadRequest();
            }
            //When List is completed this code will send a message to hangfireservices
            //var list = new ShoppingListUpdateDto { Id = request.Id, IsCompleted = request.IsCompleted };
            //_rabbitmqManager.Publish(list, "direct", "direct.test", "direct.queuName", "direct.test.key");
            return Ok(result);

        }

    }
}
