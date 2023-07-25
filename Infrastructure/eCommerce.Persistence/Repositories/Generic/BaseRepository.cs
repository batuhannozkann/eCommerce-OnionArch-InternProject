using eCommerce.Application.Repositories;
using eCommerce.Domain.Entities.Common;
using eCommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Repositories.Generic
{
    public class BaseRepository<T>:IBaseRepository<T>
        where T:BaseEntity
    {
        private readonly eCommerceDbContext _context;

        public BaseRepository(eCommerceDbContext context)
        {
            _context = context;
        }

        private DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll()
        => Table.AsQueryable();
        //AsNoTrackingIdentityResolution 
        public async Task<T> GetByIdAsync(long id)
        => await Table.FindAsync(id);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.AsQueryable().Where(method);
        public async Task<T> AddAsync(T model)
        {
            await Table.AddAsync(model);
            return model;
        }

        public async Task AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);
        }

        public async Task Remove(long id)
        {
            T model = await Table.FindAsync(id);
            Table.Remove(model);
            
        }

        public void Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            
        }

        public void RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            
        }

        public void Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            
        }
        public async Task<int> SaveAsync()

            => await _context.SaveChangesAsync();

    }

}

