using SmartStore.Domain.Entities;
using SmartStore.Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Domain.Abstraction.ItemManagement
{
    public interface IItemRepo : IRepository<Item>
    {
    }
}
