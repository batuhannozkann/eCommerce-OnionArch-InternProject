﻿using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Repositories
{
    public interface IProductRepository:IBaseRepositoryNoTracking<Product>
    {
        public IQueryable<Product> GetAllWithCategory();
    }
}
