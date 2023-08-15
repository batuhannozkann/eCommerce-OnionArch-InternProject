using eCommerce.Application.UnitOfWork;
using eCommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private eCommerceDbContext _context;

        public UnitOfWork(eCommerceDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        
       
    }
}
