﻿using eCommerce.Application.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Persistence.Contexts;
using eCommerce.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Repositories
{
    public class ProductRepository : BaseRepositoryNoTracking<Product>, IProductRepository
    {
        private readonly eCommerceDbContext _context;
        private DbSet<Product> Table => _context.Products;
        
       
        public ProductRepository(eCommerceDbContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Product> GetAllWithCategory()
        {
            return Table.Include(x => x.ProductCategories).ThenInclude(x => x.Category).AsQueryable();
        }
        
    }
}
