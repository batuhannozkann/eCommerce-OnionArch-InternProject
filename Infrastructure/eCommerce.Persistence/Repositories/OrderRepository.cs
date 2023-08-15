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
    public class OrderRepository : BaseRepository<Order>,IOrderRepository
    {
        private eCommerceDbContext _context;
        public OrderRepository(eCommerceDbContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Order> GetAll()
        {
            return _context.Orders.Include(x=>x.ProductOrders).ThenInclude(x=>x.Product).Include(x=>x.Shipping).Include(x => x.Address).Include(x => x.User).AsQueryable();
        }
    }
}
