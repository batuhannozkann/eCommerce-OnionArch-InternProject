using eCommerce.Application.Repositories;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Products;
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
    public class CategoryRepository : BaseRepositoryNoTracking<Category>, ICategoryRepository
    {
        private readonly eCommerceDbContext _context;
        private DbSet<Category> Table => _context.Categories;

        public CategoryRepository(eCommerceDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Category> GetAllWithProduct()
        {
            return _context.Categories.Include(x => x.ProductCategories).ThenInclude(x => x.Product).ToList();
            
        }

    }
}
