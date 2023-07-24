using AutoMapper;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Services
{
    public class ProductService : ServiceWithDto<ProductDto, Product>,IProductService
    {
        public ProductService(IMapper mapper, IBaseRepository<Product> baseRepository) : base(mapper, baseRepository)
        {

        }
    }
}
