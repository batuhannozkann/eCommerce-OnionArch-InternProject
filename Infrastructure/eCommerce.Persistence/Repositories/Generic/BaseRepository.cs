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
    public class BaseRepository<T>
        where T:BaseEntity
    {
        private readonly eCommerceDbContext _context;

        public BaseRepository(eCommerceDbContext context)
        {
            _context = context;
        }

        private DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll(bool tracking = true)
        => tracking ? Table.AsQueryable() : Table.AsQueryable().AsNoTracking();
        public async Task<T> GetByIdAsync(long id, bool tracking = true)
        => tracking ? await Table.FindAsync(id) : await Table.AsQueryable().AsNoTracking().FirstOrDefaultAsync(data => data.Id == id);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        => tracking ? await Table.FirstOrDefaultAsync(method) : await Table.AsQueryable().AsNoTracking().FirstOrDefaultAsync();

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        => tracking ? Table.AsQueryable().Where(method) : Table.AsQueryable().AsNoTracking().Where(method);
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);
            return true;
        }

        public async Task<bool> Remove(long id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
            Table.Remove(model);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()

            => await _context.SaveChangesAsync();

    }

}

