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
    public class ShippingRepository : BaseRepository<Shipping>, IShippingRepository
    {
        private eCommerceDbContext _context;
        public ShippingRepository(eCommerceDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ICollection<Shipping>> GetAll()
        {
            return await _context.Shippings.Include(x => x.Order).ThenInclude(x => x.ProductOrders).Include(x => x.User).Include(x => x.Address)
                .Include(x => x.ShippingCompany).Include(x => x.ShippingProducts).ThenInclude(x => x.Product)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

    }
}
