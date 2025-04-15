using AutoMapper;
using AutoMapper.QueryableExtensions;
using SmartStore.Core.Responses;
using SmartStore.Core.Services.ItemsMangement.Abstraction;
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
    public class ItemGroupService: Abstraction.IItemGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IItemGroupRepo _itemGroupRepo;
        private readonly IMessageService _messageService;
        public ItemGroupService(IUnitOfWork unitOfWork, IMapper mapper, IItemGroupRepo itemGroupRepo, IMessageService messageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _itemGroupRepo = itemGroupRepo;
            _messageService = messageService;
        }

        public async Task<ServiceResult> AddItemGroupAsync(ItemGroupReq request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.NameArabic))
                return ServiceResult.Failure(_messageService.GetMessage("EmptyValue"));

            var isExists = await _itemGroupRepo
                .GetAsync(c => c.NameArabic == request.NameArabic && c.IsDeleted == false);

            if (isExists != null)
                return ServiceResult.Failure(_messageService.GetMessage("ItemGroupExists"));

            var entity = _mapper.Map<ItemGroup>(request);

            await _itemGroupRepo.AddAsync(entity);
            await _unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(_messageService.GetMessage("RegisterSuccessfully"));
        }

        public async Task<PaginationObject<ItemGroupResp>> GetItemsGroupsAsync(int pageIndex)
        {
            var query = (_itemGroupRepo.GetAllAsync(i => i.IsDeleted == false))
            .OrderBy(i => i.NameArabic)
            .ProjectTo<ItemGroupResp>(_mapper.ConfigurationProvider);
            return await PaginationHelper.CreateAsync(query, pageIndex);
        }

        public async Task<ServiceResult> UpdateItemGroupAsync(int itemGroupId, ItemGroupReq request)
        {

            if (itemGroupId == 0)
            {
                return ServiceResult.Failure(_messageService.GetMessage("InvalidId"));
            }

            if (request == null || string.IsNullOrWhiteSpace(request.NameArabic))
            {
                return ServiceResult.Failure(_messageService.GetMessage("EmptyValue"));
            }

            var itemGroup = await _itemGroupRepo
                .GetAsync(ic => ic.ItemGroupId == itemGroupId && ic.IsDeleted == false);

            if (itemGroup == null)
            {
                return ServiceResult.Failure(_messageService.GetMessage("ValueNotFound"));
            }

            _mapper.Map(request, itemGroup);
            await _itemGroupRepo.UpdateAsync(itemGroup);
            await _unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(_messageService.GetMessage("UpdateSuccessfully"));
        }

        public async Task<ServiceResult> DeleteItemGroupAsync(int itemGroupId)
        {
            if (itemGroupId != 0)
            {
                var itemGroup = await _itemGroupRepo
                 .GetAsync(ic => ic.ItemGroupId == itemGroupId && ic.IsDeleted == false);

                if (itemGroup != null)
                {
                    itemGroup.IsDeleted = true;
                    await _itemGroupRepo.UpdateAsync(itemGroup);
                    await _unitOfWork.SaveChangeAsync();

                    return ServiceResult.Success(_messageService.GetMessage("DeleteSuccessfully"));
                }
            }
            return ServiceResult.Failure(_messageService.GetMessage("ValueNotFound"));
        }

        public async Task<PaginationObject<ItemGroupResp>> SearchItemGroupAsync(string input, int pageIndex)
        {
            if (!string.IsNullOrEmpty(input))
            {
                int.TryParse(input, out int id);

                var itemsGroups = _itemGroupRepo.GetAllAsync(ic =>
                    (ic.ItemGroupId == id || ic.NameArabic.Contains(input) || ic.NameEnglish.Contains(input)) && ic.IsDeleted == false);

                if (itemsGroups.Any())
                {
                    var res = itemsGroups.OrderBy(i => i.ItemGroupId)
                     .ProjectTo<ItemGroupResp>(_mapper.ConfigurationProvider);

                    return await PaginationHelper.CreateAsync(res, pageIndex);
                }
            }
            return null;
        }

        public async Task<ItemGroupResp> GetItemGroupByIdAsync(int itemGroupId)
        {
            var itemGroup = await _itemGroupRepo
                .GetAsync(ic => ic.ItemGroupId == itemGroupId && ic.IsDeleted == false);

            if (itemGroup != null)
            {
                var itemGroupResp = _mapper.Map<ItemGroupResp>(itemGroup);
                return itemGroupResp;
            }
            return null;
        }

    }
}
