using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Common;
using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface IServiceWithDto<Dto,T>
        where T:BaseEntity where Dto:BaseDto
        
    {
        IDataResult<IQueryable<Dto>> GetAll();
        Task<IDataResult<Dto>> GetByIdAsync(long id);
        Task<IDataResult<Dto>> GetSingleAsync(Expression<Func<Dto, bool>> method);
        IDataResult<IQueryable<Dto>> GetWhere(Expression<Func<Dto, bool>> method);
        Task<IDataResult<Dto>> AddAsync(Dto model);
        Task<IDataResult<List<Dto>>> AddRangeAsync(List<Dto> model);
        Task<IDataResult<Dto>> Remove(long id);
        IDataResult<Dto> Remove(Dto model);
        IDataResult<List<Dto>> RemoveRange(List<int> ids);
        IDataResult<Dto> Update(Dto model);
    }
}
