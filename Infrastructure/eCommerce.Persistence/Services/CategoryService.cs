using AutoMapper;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.UnitOfWork;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Categories;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Utilities.Results;
using eCommerce.Persistence.Repositories;
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
        private IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryCreateDto model)
        {
            Category category = _mapper.Map<Category>(model);
            Category addedCategory= await _categoryRepository.AddAsync(category);
            await _unitOfWork.CommitAsync();
            CategoryDto addedCategoryDto = _mapper.Map<CategoryDto>(addedCategory);
            return new SuccessDataResult<CategoryDto>(addedCategoryDto, 200);

        }

        public async Task<IDataResult<List<CategoryDto>>> AddRangeAsync(List<CategoryCreateDto> models)
        {
            List<Category> categories = _mapper.Map<List<CategoryCreateDto>,List<Category>>(models);
            List<Category> addedCategory = await _categoryRepository.AddRangeAsync(categories);
            await _unitOfWork.CommitAsync();
            List<CategoryDto> addedCategoryDtos = _mapper.Map<List<Category>,List<CategoryDto>>(addedCategory);
            return new SuccessDataResult<List<CategoryDto>>(addedCategoryDtos, 200);
        }

        public IDataResult<List<CategoryDto>> GetAll()
        {
            List<Category> categories = _categoryRepository.GetAll().Where(x => x.IsDeleted == false).ToList();
            List<CategoryDto> categoryDtos = _mapper.Map<List<Category>,List<CategoryDto>>(categories);
            return new SuccessDataResult<List<CategoryDto>>(categoryDtos, 200);
        }

        public IDataResult<List<CategoryDto>> GetAllAsNoTrackingWithIdentityResolution()
        {
            List<Category> categories = _categoryRepository.GetAllAsNoTrackingWithIdentityResolution().Where(x => x.IsDeleted == false).ToList();
            List<CategoryDto> categoryDtos = _mapper.Map<List<Category>, List<CategoryDto>>(categories);
            return new SuccessDataResult<List<CategoryDto>>(categoryDtos, 200);
        }

        public IDataResult<List<CategoryWithProductsDto>> GetAllWithProduct()
        {
            List<Category> categories = _categoryRepository.GetAllWithProduct().Where(x => x.IsDeleted == false).ToList();
            if (categories == null) return new ErrorDataResult<List<CategoryWithProductsDto>>("Category has not found", 400);
            List<CategoryWithProductsDto> categoryDtos = _mapper.Map<List<Category>, List<CategoryWithProductsDto>>(categories);
            return new SuccessDataResult<List<CategoryWithProductsDto>>(categoryDtos, 200);
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

        public async Task<IDataResult<CategoryDto>> Remove(long id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);
            await _categoryRepository.Remove(id);
            _unitOfWork.Commit();
            return new SuccessDataResult<CategoryDto>(categoryDto, 200);
        }

        public Task<IDataResult<List<CategoryDto>>> RemoveRange(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryDto model)
        {
            Category category = await _categoryRepository.GetByIdAsync(model.Id);
            if (category == null) return new ErrorDataResult<CategoryDto>("Category has not found", 400);
            category.Name = model.Name ?? category.Name;
            await _unitOfWork.CommitAsync();
            CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);
            return new SuccessDataResult<CategoryDto>(categoryDto, 200);
            
        }
    }
}
