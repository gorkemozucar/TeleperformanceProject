using Application.Dtos;
using Application.Features.ShoppingListItems.Requests.Commands;
using Application.Features.ShoppingLists.Requests.Commands;
using Application.Models;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ShoppingListItem, CreateShoppingListItemCommand>().ReverseMap();
            CreateMap<ShoppingListItem,ShoppingListItemDto>().ReverseMap();
            CreateMap<ShoppingListItem,UpdateShoppingListCommand>().ReverseMap();
            CreateMap<ShoppingListItem, ShoppingListItemUpdateDto>().ReverseMap();

            CreateMap<ShoppingList, CreateShoppingListCommand>().ReverseMap();
            CreateMap<ShoppingList, ShoppingListDto>().ReverseMap();
            CreateMap<ShoppingList, UpdateShoppingListCommand>().ReverseMap();
            CreateMap<ShoppingList, ShoppingListUpdateDto>().ReverseMap();

            CreateMap<RegisterRequestDto, AppUser>().ReverseMap();
            CreateMap<RegisterResponseDto, AppUser>().ReverseMap();

        }
    }
}
