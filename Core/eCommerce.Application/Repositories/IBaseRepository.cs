using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Repositories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(long id);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> AddAsync(T model);
        Task<List<T>> AddRangeAsync(List<T> model);
        Task Remove(long id);
         void Remove(T model);
         void RemoveRange(List<T> datas);
         void Update(T model);
        Task<int> SaveAsync();

    }
}
