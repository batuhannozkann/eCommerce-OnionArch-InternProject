using eCommerce.Application.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Persistence.Contexts;
using eCommerce.Persistence.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Repositories
{
    public class ShippingCompanyRepository : BaseRepository<ShippingCompany>, IShippingCompanyRepository
    {
       private  eCommerceDbContext _context;
        public ShippingCompanyRepository(eCommerceDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
