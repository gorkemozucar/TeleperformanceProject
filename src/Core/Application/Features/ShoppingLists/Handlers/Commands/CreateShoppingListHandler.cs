using Application.Constants;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Dtos;
using Application.Features.ShoppingLists.Requests.Commands;
using Application.Wrapper;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.ShoppingLists.Handlers.Commands
{
    public class CreateShoppingListHandler : IRequestHandler<CreateShoppingListCommand, ServiceResponse<ShoppingListDto>>
    {
        private readonly IShoppingListWriteRepository _shoppingListWriteRepository;
        private readonly IMapper _mapper;

        public CreateShoppingListHandler(IShoppingListWriteRepository shoppingListWriteRepository, IMapper mapper)
        {
            _shoppingListWriteRepository = shoppingListWriteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ShoppingListDto>> Handle(CreateShoppingListCommand request, CancellationToken cancellationToken)
        {
            var entityToAdd = _mapper.Map<ShoppingList>(request);
            var result = await _shoppingListWriteRepository.AddAsync(entityToAdd);
            return new ServiceResponse<ShoppingListDto>(_mapper.Map<ShoppingListDto>(result), true, 204, Messages.ShoppingListCreated);
        }
    }
}
