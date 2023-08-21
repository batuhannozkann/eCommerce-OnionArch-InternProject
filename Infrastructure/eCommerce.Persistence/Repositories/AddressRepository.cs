using eCommerce.Application.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Persistence.Contexts;
using eCommerce.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        private eCommerceDbContext _context;
        public AddressRepository(eCommerceDbContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Address> GetAll()
        {
            return _context.Addresses.Include(x => x.User).AsQueryable();
        }
        public async Task<Address> GetByIdAsync(long id)
        {
            return await _context.Addresses.Where(x => x.Id == id).Include(x => x.User).FirstOrDefaultAsync();
        }
    }
}
