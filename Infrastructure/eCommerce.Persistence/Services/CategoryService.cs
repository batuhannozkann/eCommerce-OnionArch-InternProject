using AutoMapper;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Categories;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryCreateDto model)
        {
            Category category = _mapper.Map<Category>(model);
            Category addedCategory= await _categoryRepository.AddAsync(category);
            CategoryDto addedCategoryDto = _mapper.Map<CategoryDto>(addedCategory);
            await _categoryRepository.SaveAsync();
            return new SuccessDataResult<CategoryDto>(addedCategoryDto, 200);

        }

        public Task<IDataResult<List<CategoryCreateDto>>> AddRangeAsync(List<CategoryCreateDto> models)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CategoryDto>> GetAll()
        {
            List<Category> categories = _categoryRepository.GetAll().ToList();
            List<CategoryDto> categoryDtos = _mapper.Map<List<Category>,List<CategoryDto>>(categories);
            return new SuccessDataResult<List<CategoryDto>>(categoryDtos, 200);
        }

        public IDataResult<List<CategoryDto>> GetAllAsNoTrackingWithIdentityResolution()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductWithCategoryDto>> GetAllWithProduct()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CategoryDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CategoryDto>> GetSingleAsync(Expression<Func<Category, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CategoryDto>> GetWhere(Expression<Func<Category, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CategoryDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<Category, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CategoryDto>> Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<CategoryDto>>> RemoveRange(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CategoryDto>> Update(CategoryDto model)
        {
            throw new NotImplementedException();
        }
    }
}
