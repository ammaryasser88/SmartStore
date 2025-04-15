using AutoMapper;
using SmartStore.Domain.DTOs.Request.ItemsMangement;
using SmartStore.Domain.DTOs.Response;
using SmartStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZadRestaurant.Core.MapperConfiguration.InventoryManagement
{
    public class ItemCategoryProfile : Profile
    {
        public ItemCategoryProfile()
        {
            CreateMap<ItemCategoryReq, ItemCategory>()
                .ForMember(dest => dest.IsDeleted, obj => obj.MapFrom(src => false))
                .ForMember(dest => dest.IsActive, obj => obj.MapFrom(src => true)).ReverseMap();
            //CreateMap<ItemCategoryResp, ItemCategory>();
            CreateMap<ItemCategory, ItemCategoryResp>().ReverseMap();
        }
    }
}
