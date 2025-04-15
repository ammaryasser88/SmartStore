using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadRestaurant.Domain.Abstraction;

namespace ZadRestaurant.Core.Repositories
{
    public class GenericSPRepository<T> : IGenericSPRepository<T> where T : class
    {
        private DbContext _dbContext;
        private DbSet<T> _dbSet;

        public GenericSPRepository(DbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();

        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public async Task<IEnumerable<T>> GetAsync(string procedureName, object[] prarameters)
        {
            try
            {
                var result = _dbSet.FromSqlRaw(procedureName, prarameters).AsEnumerable();

                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }



    }
}
