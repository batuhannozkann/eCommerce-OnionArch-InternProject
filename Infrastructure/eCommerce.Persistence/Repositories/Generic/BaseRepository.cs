using eCommerce.Application.Repositories;
using eCommerce.Domain.Entities.Common;
using eCommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<List<T>> AddRangeAsync(List<T> model)
            
        {
            await Table.AddRangeAsync(model);
            return model;

        }

        public async Task Remove(long id)
        {
            T model = await Table.FindAsync(id);
            model.IsDeleted = true;
            model.DeletedTime = DateTime.UtcNow;
            
        }

        public void Remove(T model)
        {
            model.IsDeleted = true;
            model.DeletedTime=DateTime.UtcNow;
            
        }

        public void RemoveRange(List<T> datas)
        {
            foreach (T data in datas)
            {
                data.IsDeleted = true;
                data.DeletedTime = DateTime.UtcNow;
            }
            
        }

        public void Update(T model)
        {
            Table.Entry(model).State = EntityState.Modified;
            
            
        }
        public async Task<int> SaveAsync()

            => await _context.SaveChangesAsync();

    }

}

