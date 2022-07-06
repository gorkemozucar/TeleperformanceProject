using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Dtos;
using Application.Features.ShoppingLists.Requests.Commands;
using Application.Wrapper;
using AutoMapper;
using MediatR;

namespace Application.Features.ShoppingLists.Handlers.Commands
{
    public class UpdateShoppingListCommandHandler : IRequestHandler<UpdateShoppingListCommand, ServiceResponse<ShoppingListUpdateDto>>
    {
        private readonly IShoppingListReadRepository _shoppingListReadRepository;
        private readonly IShoppingListWriteRepository _shoppingListWriteRepository;
        private readonly IMapper _mapper;

        public UpdateShoppingListCommandHandler(IShoppingListReadRepository shoppingListReadRepository, IShoppingListWriteRepository shoppingListWriteRepository, IMapper mapper)
        {
            _shoppingListReadRepository = shoppingListReadRepository;
            _shoppingListWriteRepository = shoppingListWriteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ShoppingListUpdateDto>> Handle(UpdateShoppingListCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _shoppingListReadRepository.GetById(request.Id);
            if (entityToUpdate == null)
            {
                return new ServiceResponse<ShoppingListUpdateDto>(default, false, 404, Messages.ShoppingListNotFound);
            }
            entityToUpdate = _mapper.Map(request, entityToUpdate);
            _shoppingListWriteRepository.Update(entityToUpdate);
            return new ServiceResponse<ShoppingListUpdateDto>(_mapper.Map<ShoppingListUpdateDto>(entityToUpdate), true, 200, Messages.ShoppingListUpdated);
            throw new NotImplementedException();
        }
    }
}
