using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Shared.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        Task<int> SaveChangeAsync();
    }
}
