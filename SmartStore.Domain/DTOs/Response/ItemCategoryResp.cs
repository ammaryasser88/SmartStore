using SmartStore.Domain.DTOs.Request.ItemsMangement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Domain.DTOs.Response
{
    public class ItemCategoryResp:ItemGroupReq
    {
        public int CategoryId { get; set; }
    }
}
