using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Repositories
{
    public interface IBaseRepositoryNoTracking<T>:IBaseRepository<T>
        where T:BaseEntity
    {
        public IQueryable<T> GetAllAsNoTrackingWithIdentityResolution();
        public IQueryable<T> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<T, bool>> method);
    }
}
