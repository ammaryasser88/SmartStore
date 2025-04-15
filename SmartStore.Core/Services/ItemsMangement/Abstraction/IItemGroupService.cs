using SmartStore.Core.Responses;
using SmartStore.Domain.DTOs.Request.ItemsMangement;
using SmartStore.Domain.DTOs.Response;
using SmartStore.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Core.Services.ItemsMangement.Abstraction
{
    public interface IItemGroupService
    {
        Task<ServiceResult> AddItemGroupAsync(ItemGroupReq request);
        Task<PaginationObject<ItemGroupResp>> GetItemsGroupsAsync(int pageIndex);
        Task<ServiceResult> DeleteItemGroupAsync(int itemGroupId);
        Task<ServiceResult> UpdateItemGroupAsync(int itemGroupId, ItemGroupReq request);
        Task<PaginationObject<ItemGroupResp>> SearchItemGroupAsync(string input, int pageIndex);
        Task<ItemGroupResp> GetItemGroupByIdAsync(int itemGroupId);
    }
}
