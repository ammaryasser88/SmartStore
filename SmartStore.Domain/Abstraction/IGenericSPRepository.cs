using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadRestaurant.Domain.Abstraction
{
    public interface IGenericSPRepository<T> : IGenericSPRepository, IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAsync(string procedureName, params object[] prarameters);

    }

    public interface IGenericSPRepository
    {

    }
}
