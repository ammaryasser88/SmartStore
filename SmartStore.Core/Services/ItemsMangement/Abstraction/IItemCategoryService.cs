using SmartStore.Core.Responses;
using SmartStore.Domain.DTOs.Request.ItemsMangement;
using SmartStore.Domain.DTOs.Response;
using SmartStore.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Core.Services.Shared.Abstraction
{
    public interface IItemCategoryService
    {
        Task<ServiceResult> AddItemCategoryAsync(ItemCategoryReq request);
        Task<PaginationObject<ItemCategoryResp>> GetItemsCategoriesAsync(int pageIndex);
        Task<ServiceResult> DeleteItemCategoryAsync(int itemCategoryId);
        Task<ServiceResult> UpdateItemCategoryAsync(int itemCategoryId, ItemCategoryReq request);
        Task<PaginationObject<ItemCategoryResp>> SearchItemCategoryAsync(string input, int pageIndex);
        Task<ItemCategoryResp> GetItemCategoryByIdAsync(int itemCategoryId);
    }
}
