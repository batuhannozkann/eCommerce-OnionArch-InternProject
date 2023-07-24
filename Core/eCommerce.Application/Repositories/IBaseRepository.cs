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
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);
        Task<bool> Remove(long id);
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        bool Update(T model);
        Task<int> SaveAsync();

    }
}
