using eCommerce.Application.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Common;
using eCommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Repositories.Generic
{
    public class BaseRepositoryNoTracking<T> : BaseRepository<T>, IBaseRepository<T>
        where T : BaseEntity
    {
        private  eCommerceDbContext _context;
        public BaseRepositoryNoTracking(eCommerceDbContext context) : base(context)
        {
            _context = context;
        }
        private DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAllAsNoTrackingWithIdentityResolution()
        {
            return Table.AsNoTrackingWithIdentityResolution();
        }
        public IQueryable<T> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<T, bool>> method)
        {
            return Table.Where(method).AsNoTrackingWithIdentityResolution();
        }
    }
}
