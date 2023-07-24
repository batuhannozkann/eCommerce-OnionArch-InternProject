using eCommerce.Application.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface IServiceNoTracking<T>:IService<T>
    {
        public IDataResult<IQueryable<T>> GetAllAsNoTrackingWithIdentityResolution();
        public IDataResult<IQueryable<T>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<T, bool>> method);
    }
}
