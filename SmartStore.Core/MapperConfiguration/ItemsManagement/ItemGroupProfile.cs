using AutoMapper;
using SmartStore.Domain.DTOs.Request.ItemsMangement;
using SmartStore.Domain.DTOs.Response;
using SmartStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Core.MapperConfiguration.ItemsManagement
{
    public class ItemGroupProfile :Profile
    {
        public ItemGroupProfile()
        {
            CreateMap<ItemGroupReq, ItemGroup>()
                .ForMember(dest => dest.IsDeleted, obj => obj.MapFrom(src => false))
                .ForMember(dest => dest.IsActive, obj => obj.MapFrom(src => true)).ReverseMap();
            CreateMap<ItemGroup, ItemGroupResp>().ReverseMap();
        }
    }
}
