using SmartStore.Domain.Context;
using SmartStore.Domain.Entities;
using SmartStore.Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Domain.Abstraction.ItemManagement
{
    public class ItemRepo : Repository<Item> ,IItemRepo
    {
        public ItemRepo(SmartStoreContext smartStoreContext) : base(smartStoreContext)
        {
            
        }
    }
}
