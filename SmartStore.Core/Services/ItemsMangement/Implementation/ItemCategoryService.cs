using AutoMapper;
using AutoMapper.QueryableExtensions;
using SmartStore.Core.Responses;
using SmartStore.Core.Services.Shared.Abstraction;
using SmartStore.Domain.Abstraction.ItemsManagement;
using SmartStore.Domain.DTOs.Request.ItemsMangement;
using SmartStore.Domain.DTOs.Response;
using SmartStore.Domain.Entities;
using SmartStore.Shared.DTOs;
using SmartStore.Shared.PaginationHelper;
using SmartStore.Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Core.Services.ItemsMangement.Implementation
{
    public class ItemCategoryService : IItemCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IItemCategoryRepo _itemCategoryRepo;
        private readonly IMessageService _messageService;
        public ItemCategoryService(IUnitOfWork unitOfWork, IMapper mapper, IItemCategoryRepo itemCategoryRepo, IMessageService messageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _itemCategoryRepo = itemCategoryRepo;
            _messageService = messageService;
        }

        public async Task<ServiceResult> AddItemCategoryAsync(ItemCategoryReq request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.NameArabic))
                return ServiceResult.Failure(_messageService.GetMessage("EmptyValue"));

            var isExists = await _itemCategoryRepo
                .GetAsync(c => c.NameArabic == request.NameArabic && c.IsDeleted==false);

            if (isExists!=null)
                return ServiceResult.Failure(_messageService.GetMessage("ItemCategoryExists"));

            var entity = _mapper.Map<ItemCategory>(request);

            await _itemCategoryRepo.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(_messageService.GetMessage("RegisterSuccessfully"));
        }

        public async Task<PaginationObject<ItemCategoryResp>> GetItemsCategoriesAsync(int pageIndex)
        {
            var query = ( _itemCategoryRepo.GetAllAsync(i =>i.IsDeleted==false))
            .OrderBy(i=>i.NameArabic)
            .ProjectTo<ItemCategoryResp>(_mapper.ConfigurationProvider);
            return await PaginationHelper.CreateAsync(query,pageIndex);
        }

        public async Task<ServiceResult> UpdateItemCategoryAsync(int itemCategoryId, ItemCategoryReq request)
        {
            
            if (itemCategoryId == 0)
            {
                return ServiceResult.Failure(_messageService.GetMessage("InvalidId"));
            }

            if (request == null || string.IsNullOrWhiteSpace(request.NameArabic))
            {
                return ServiceResult.Failure(_messageService.GetMessage("EmptyValue"));
            }
           
            var itemCategory = await _itemCategoryRepo
                .GetAsync(ic => ic.CategoryId == itemCategoryId && ic.IsDeleted == false);

            if (itemCategory == null)
            {
                return ServiceResult.Failure(_messageService.GetMessage("ValueNotFound"));
            }

            _mapper.Map(request, itemCategory);
            await _itemCategoryRepo.UpdateAsync(itemCategory);
            await _unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(_messageService.GetMessage("UpdateSuccessfully"));
        }

        public async Task<ServiceResult> DeleteItemCategoryAsync(int itemCategoryId)
        {
            if(itemCategoryId!=0)
            {
                var itemCategory = await _itemCategoryRepo
                 .GetAsync(ic => ic.CategoryId == itemCategoryId && ic.IsDeleted == false);

                if (itemCategory != null)
                {
                    itemCategory.IsDeleted = true;
                    await _itemCategoryRepo.UpdateAsync(itemCategory);
                    await _unitOfWork.SaveChangeAsync();

                    return  ServiceResult.Success(_messageService.GetMessage("DeleteSuccessfully"));
                }
            }
            return ServiceResult.Failure(_messageService.GetMessage("ValueNotFound"));
        }

        public async Task<PaginationObject<ItemCategoryResp>> SearchItemCategoryAsync(string input, int pageIndex)
        {
            if (!string.IsNullOrEmpty(input))
            {
                int.TryParse(input, out int id);

                var itemsCategories = _itemCategoryRepo.GetAllAsync(ic =>
                    (ic.CategoryId == id || ic.NameArabic.Contains(input) || ic.NameEnglish.Contains(input)) && ic.IsDeleted == false);

                if (itemsCategories.Any())
                {
                    var res = itemsCategories.OrderBy(i => i.CategoryId)
                     .ProjectTo<ItemCategoryResp>(_mapper.ConfigurationProvider);

                    return await PaginationHelper.CreateAsync(res, pageIndex);
                }
            }
            return null;
        }

        public async Task<ItemCategoryResp> GetItemCategoryByIdAsync(int categoryId)
        {
            var itemCategory = await _itemCategoryRepo
                .GetAsync(ic => ic.CategoryId == categoryId && ic.IsDeleted == false);

            if (itemCategory != null)
            {
                var itemCategoryResp = _mapper.Map<ItemCategoryResp>(itemCategory);
                return itemCategoryResp;
            }
            return null;
        }

    }

}
