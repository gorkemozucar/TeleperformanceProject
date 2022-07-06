using Application.Constants;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Dtos;
using Application.Features.ShoppingListItems.Requests.Commands;
using Application.Wrapper;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.ShoppingListItems.Handlers.Commands
{
    public class CreateShoppingListItemHandler : IRequestHandler<CreateShoppingListItemCommand, ServiceResponse<ShoppingListItemDto>>
    {
        private readonly IShoppingListItemWriteRepository _shoppingListItemWriteRepository;
        private readonly IMapper _mapper;

        public CreateShoppingListItemHandler(IShoppingListItemWriteRepository shoppingListItemWriteRepository, IMapper mapper)
        {
            _shoppingListItemWriteRepository = shoppingListItemWriteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ShoppingListItemDto>> Handle(CreateShoppingListItemCommand request, CancellationToken cancellationToken)
        {
            var entityToAdd = _mapper.Map<ShoppingListItem>(request);
            var result = await _shoppingListItemWriteRepository.AddAsync(entityToAdd);
            return new ServiceResponse<ShoppingListItemDto>(_mapper.Map<ShoppingListItemDto>(result), true, 204, Messages.ShoppingListItemCreated);
        }
    }
}
