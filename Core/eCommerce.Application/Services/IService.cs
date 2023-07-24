using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface IService<T>

    {
        IDataResult<IQueryable<T>> GetAll();
        Task<IDataResult<T>> GetByIdAsync(long id);
        Task<IDataResult<T>> GetSingleAsync(Expression<Func<T, bool>> method);
        IDataResult<IQueryable<T>> GetWhere(Expression<Func<T, bool>> method);
        Task<IDataResult<T>> AddAsync(T model);
        Task<IDataResult<List<T>>> AddRangeAsync(List<T> model);
        Task<IDataResult<T>> Remove(long id);
        IDataResult<T> Remove(T model);
        IDataResult<List<T>> RemoveRange(List<T> datas);
        IDataResult<T> Update(T model);
        Task<int> SaveAsync();
    }
}
