using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface IProductService 
    {
        Task<IDataResult<List<ProductCreateDto>>> AddRangeAsync(List<ProductCreateDto> models);
        IDataResult<List<ProductDto>> GetAll();
        IDataResult<List<ProductWithCategoryDto>> GetAllWithCategory();
        Task<IDataResult<ProductDto>> GetByIdAsync(long id);
        Task<IDataResult<ProductDto>> GetSingleAsync(Expression<Func<Product, bool>> method);
        IDataResult<List<ProductDto>> GetWhere(Expression<Func<Product, bool>> method);
        Task<IDataResult<ProductCreateDto>> AddAsync(ProductCreateDto model);
        Task<IDataResult<ProductDto>> Remove(long id);
        Task<IDataResult<List<ProductDto>>> RemoveRange(List<int> ids);
        Task<IDataResult<ProductDto>> Update(ProductDto model);
        public IDataResult<List<ProductDto>> GetAllAsNoTrackingWithIdentityResolution();
        public IDataResult<List<ProductDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<Product, bool>> method);
    }
}
