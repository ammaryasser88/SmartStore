using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Shared.UnitOfWork
{
    public interface IRepository<T> : IRepository, IDisposable where T : class
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<bool> AddRangeAsync(List<T> entities);
        void Delete(T entity);
        void Delete(object id);
        void Delete(long id);

        void Delete(Guid id);
        void Remove(T entity);
        T Update(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllAsync();
        Task<IQueryable<T>> GetAllIncludeAsync(params Expression<Func<T, object>>[] including);
        IQueryable<T> GetAllAsync(Expression<Func<T, bool>> predict);
        Task<T> GetByIdAsync(int id);
        Task DeleteAsync(T entity);

        T GetIncluding(Expression<Func<T, object>> including, Expression<Func<T, bool>> filter);
        Task<T> GetIncludingAsync(Expression<Func<T, object>> including, Expression<Func<T, bool>> filter);
        Task<bool> UpdateRangeAsync(IEnumerable<T> entities);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predict);
        IQueryable<T> GetList(Expression<Func<T, bool>> predict);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predict);
        IQueryable<T> GetListIncluding(Expression<Func<T, object>> including, Expression<Func<T, bool>> filter);
        IQueryable<T> GetListIncluding2(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] including);
        Task<IQueryable<T>> GetListIncludingAsync(Expression<Func<T, object>> including, Expression<Func<T, bool>> filter);
        IQueryable<T> GetListIncludingAsync(Expression<Func<T, object>> including);
        void DeleteRange(IEnumerable<T> entities);
        T Get(Expression<Func<T, bool>> predict);
        Task<T> GetAsync(Expression<Func<T, bool>> predict);
        Task<long> CountAsync(Expression<Func<T, bool>> predict);
        long Count(Expression<Func<T, bool>> predict);
        Task<T> GetIncludesAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        T GetIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetListIncludesAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> FromSql(string storedName, object[] parameters);
    }
    public interface IRepository
    {
    }
}
