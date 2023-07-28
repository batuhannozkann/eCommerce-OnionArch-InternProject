using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Categories;
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
    public interface ICategoryService
    {
        Task<IDataResult<List<CategoryCreateDto>>> AddRangeAsync(List<CategoryCreateDto> models);
        IDataResult<List<CategoryDto>> GetAll();
        IDataResult<List<ProductWithCategoryDto>> GetAllWithProduct();
        Task<IDataResult<CategoryDto>> GetByIdAsync(long id);
        Task<IDataResult<CategoryDto>> GetSingleAsync(Expression<Func<Category, bool>> method);
        IDataResult<List<CategoryDto>> GetWhere(Expression<Func<Category, bool>> method);
        Task<IDataResult<CategoryDto>> AddAsync(CategoryCreateDto model);
        Task<IDataResult<CategoryDto>> Remove(long id);
        Task<IDataResult<List<CategoryDto>>> RemoveRange(List<int> ids);
        Task<IDataResult<CategoryDto>> Update(CategoryDto model);
        public IDataResult<List<CategoryDto>> GetAllAsNoTrackingWithIdentityResolution();
        public IDataResult<List<CategoryDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<Category, bool>> method);
    }
}
