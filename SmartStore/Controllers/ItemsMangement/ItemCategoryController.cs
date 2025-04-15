using Microsoft.AspNetCore.Mvc;
using SmartStore.Core.Services.Shared.Abstraction;
using SmartStore.Core.Services.Shared.Implementation;
using SmartStore.Domain.DTOs.Request.ItemsMangement;
using SmartStore.Domain.DTOs.Response;
using SmartStore.Shared.ActionFilter;
using SmartStore.Shared.DTOs;

namespace SmartStore.Controllers.ItemsMangement
{
 
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IItemCategoryService _service;
        private readonly IMessageService _messageService;

        public ItemCategoryController(IItemCategoryService service, IMessageService messageservice)
        {
            _service = service;
            _messageService = messageservice;
        }

        
        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] ItemCategoryReq request)
        {
            var response = await _service.AddItemCategoryAsync(request);

            if (response.success)
            {
                return Ok(new { Message = response.message });
            }

            return BadRequest (new { Message = response.message });
        }

       
        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginationObject<ItemCategoryResp>>> GetAll([FromQuery] int pageIndex = 1)
        {
            var response = await _service.GetItemsCategoriesAsync(pageIndex);
            if (response!=null)
            {
                return Ok(response);
            }
            return NotFound(_messageService.GetMessage("ValueNotFound"));
        }

        
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById([FromQuery] int itemCategoryId)
        {
            var response = await _service.GetItemCategoryByIdAsync(itemCategoryId);
            if (response != null)
                return  Ok( response);

            return NotFound(new { Message = _messageService.GetMessage("ValueNotFound") });
        }

        
        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromQuery] int itemCategoryId, [FromBody] ItemCategoryReq request)
        {
            var response = await _service.UpdateItemCategoryAsync(itemCategoryId,request);
            if (response.success)
            {
                return Ok(new { Message = response.message });
            }

            return NotFound(new { Message = response.message });
        }

        
        [HttpPost("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int itemCategoryId)
        { 
            var response = await _service.DeleteItemCategoryAsync(itemCategoryId);

            if (response.success)
                 return Ok(new {Message = response.message });
                
            return NotFound(new { Message = response.message });
        }

        
        [HttpGet("search")]
        public async Task<ActionResult<PaginationObject<ItemCategoryResp>>> Search([FromQuery] string input, [FromQuery] int pageIndex = 1)
        {
            var response = await _service.SearchItemCategoryAsync(input, pageIndex);
            if(response!=null)
                return Ok(response);

            return NotFound(new { Message = _messageService.GetMessage("ValueNotFound") });
        }
    }

}
