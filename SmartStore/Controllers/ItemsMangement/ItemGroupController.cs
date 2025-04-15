using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStore.Core.Services.ItemsMangement.Abstraction;
using SmartStore.Core.Services.Shared.Abstraction;
using SmartStore.Domain.DTOs.Request.ItemsMangement;
using SmartStore.Domain.DTOs.Response;
using SmartStore.Shared.ActionFilter;
using SmartStore.Shared.DTOs;

namespace SmartStore.Controllers.ItemsMangement
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class ItemGroupController : ControllerBase
    {

        private readonly IItemGroupService _service;
        private readonly IMessageService _messageService;

        public ItemGroupController(IItemGroupService service, IMessageService messageservice)
        {
            _service = service;
            _messageService = messageservice;
        }


        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] ItemGroupReq request)
        {
            var response = await _service.AddItemGroupAsync(request);

            if (response.success)
            {
                return Ok(new { Message = response.message });
            }

            return BadRequest(new { Message = response.message });
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginationObject<ItemGroupResp>>> GetAll([FromQuery] int pageIndex = 1)
        {
            var response = await _service.GetItemsGroupsAsync(pageIndex);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound(_messageService.GetMessage("ValueNotFound"));
        }


        [HttpGet("GetById")]
        public async Task<ActionResult> GetById([FromQuery] int itemGroupId)
        {
            var response = await _service.GetItemGroupByIdAsync(itemGroupId);
            if (response != null)
                return Ok(response);

            return NotFound(new { Message = _messageService.GetMessage("ValueNotFound") });
        }


        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromQuery] int itemGroupId, [FromBody] ItemGroupReq request)
        {
            var response = await _service.UpdateItemGroupAsync(itemGroupId, request);
            if (response.success)
            {
                return Ok(new { Message = response.message });
            }

            return NotFound(new { Message = response.message });
        }


        [HttpPost("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int itemGroupId)
        {
            var response = await _service.DeleteItemGroupAsync(itemGroupId);

            if (response.success)
                return Ok(new { Message = response.message });

            return NotFound(new { Message = response.message });
        }


        [HttpGet("search")]
        public async Task<ActionResult<PaginationObject<ItemGroupResp>>> Search([FromQuery] string input, [FromQuery] int pageIndex = 1)
        {
            var response = await _service.SearchItemGroupAsync(input, pageIndex);
            if (response != null)
                return Ok(response);

            return NotFound(new { Message = _messageService.GetMessage("ValueNotFound") });
        }
    }
}
