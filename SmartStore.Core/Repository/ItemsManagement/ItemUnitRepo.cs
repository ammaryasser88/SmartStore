using SmartStore.Domain.Context;
using SmartStore.Domain.Entities;
using SmartStore.Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Domain.Abstraction.ItemsManagement
{
    public class ItemUnitRepo:Repository<ItemUnit>, IItemUnitRepo
    {
        public ItemUnitRepo(SmartStoreContext smartStoreContext):base(smartStoreContext)
        {
            
        }
    }
}
