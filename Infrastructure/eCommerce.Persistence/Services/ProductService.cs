using AutoMapper;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.UnitOfWork;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Utilities.Results;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<ProductCreateDto>> AddAsync(ProductCreateDto model)
        {
            Product product = _mapper.Map<Product>(model);
            List<ProductCategory> productCategories = new();
            foreach(long i in model.CategoryIds)
            {
                if(await _categoryRepository.GetByIdAsync(i) != null)
                {
                    productCategories.Add(new ProductCategory { CategoryId = i, ProductId = product.Id });
                }
            }
            product.ProductCategories = productCategories;
            Product addedProduct = await _productRepository.AddAsync(product);
            await _unitOfWork.CommitAsync();
            ProductCreateDto productCreateDto = _mapper.Map<ProductCreateDto>(addedProduct);
            return new SuccessDataResult<ProductCreateDto>(productCreateDto,"Product has successfully created",201);
        }

        public async Task<IDataResult<List<ProductCreateDto>>> AddRangeAsync(List<ProductCreateDto> models)
        {
            List<Product> products = _mapper.Map<List<ProductCreateDto>,List<Product>>(models);
            List<Product> addedProducts = await _productRepository.AddRangeAsync(products);
            _unitOfWork.Commit();
            List<ProductCreateDto> productCreateDtos = _mapper.Map<List<Product>,List < ProductCreateDto >> (addedProducts);

            return new SuccessDataResult<List<ProductCreateDto>>(productCreateDtos,200);
        }

        public IDataResult<List<ProductDto>> GetAll()
        {
            List<Product> products = _productRepository.GetAll().Where(x => x.IsDeleted == false).ToList();
            List<ProductDto> productsDto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return new SuccessDataResult<List<ProductDto>>(productsDto, 200);
        }
        public IDataResult<List<ProductDto>> GetAll(bool admin)
        {
            List<Product> products = _productRepository.GetAll().ToList();
            List<ProductDto> productsDto = _mapper.Map<List<Product>, List<ProductDto>>(products.OrderBy(x => x.Id).ToList());
            return new SuccessDataResult<List<ProductDto>>(productsDto, 200);
        }
        public IDataResult<List<ProductDto>> GetAllAsNoTrackingWithIdentityResolution()
        {
            List<Product> products = _productRepository.GetAllAsNoTrackingWithIdentityResolution().Where(x => x.IsDeleted == false).ToList();
            List<ProductDto> productDtos = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return new SuccessDataResult<List<ProductDto>>(productDtos, 200);
        }
        public IDataResult<List<ProductWithCategoryDto>> GetAllWithCategory()
        {
            List<Product> products = _productRepository.GetAllWithCategory().Where(x => x.IsDeleted == false).ToList();
            List<ProductWithCategoryDto> productWithCategoryDtos = _mapper.Map<List<Product>, List<ProductWithCategoryDto>>(products);
            return new SuccessDataResult<List<ProductWithCategoryDto>>(productWithCategoryDtos, 200);
        }

        public async Task<IDataResult<ProductDto>> GetByIdAsync(long id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            if(!product.IsDeleted)
            {
                ProductDto productDto = _mapper.Map<ProductDto>(product);
                return new SuccessDataResult<ProductDto>(productDto, 200);
            }
            return new ErrorDataResult<ProductDto>(new List<string> { "Product has not found" }, 400);
           
        }

        public async Task<IDataResult<ProductDto>> GetSingleAsync(Expression<Func<Product, bool>> method)
        {
            Product product = await _productRepository.GetSingleAsync(method);
            if (!product.IsDeleted)
            {
                ProductDto productDto = _mapper.Map<ProductDto>(product);
                return new SuccessDataResult<ProductDto>(productDto, 200);
            }
            return new ErrorDataResult<ProductDto>(new List<string> { "Product has not found" }, 400);
        }

        public IDataResult<List<ProductDto>> GetWhere(Expression<Func<Product, bool>> method)
        {
            List<Product> products = _productRepository.GetWhere(method).Where(x=>x.IsDeleted==false).ToList();
            List<ProductDto> productDtos = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return new SuccessDataResult<List<ProductDto>>(productDtos, 200);

        }

        public IDataResult<List<ProductDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<Product, bool>> method)
        {
            List<Product> products = _productRepository.GetWhereAsNoTrackingWithIdentityResolution(method).ToList();
            List<ProductDto> productDtos = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return new SuccessDataResult<List<ProductDto>>(productDtos, 200);
        }

        public async Task<IDataResult<ProductDto>> Remove(long id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            await _productRepository.Remove(id);
            _unitOfWork.Commit();
            return new SuccessDataResult<ProductDto>(productDto, 200);

        }

        public async Task<IDataResult<List<ProductDto>>> RemoveRange(List<int> ids)
        {
            List<Product> products = new();
            foreach(int id in ids)
            {
                products.Add(await _productRepository.GetByIdAsync(id));
                await _productRepository.Remove(id);
            }
            _unitOfWork.Commit();
            List<ProductDto> productDtos = _mapper.Map<List<Product>,List<ProductDto>>(products);
            return new SuccessDataResult<List<ProductDto>>(productDtos, 200);
        }

        public async Task<IDataResult<ProductDto>> Update(ProductUpdateDto model)
        {
            Product product = _productRepository.GetAllAsNoTrackingWithIdentityResolution().Where(x => x.Id == model.Id).FirstOrDefault();
            if (product == null) return new ErrorDataResult<ProductDto>("Product has not found", 400);
            product.Stock = model.Stock ?? product.Stock;
            product.Price= model.Price ?? product.Price;
            product.Description= model.Description ?? product.Description;
            product.Name = model.Name ?? product.Name;
            _productRepository.Update(product);
            await _unitOfWork.CommitAsync();
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return new SuccessDataResult<ProductDto>(productDto, 200);
        }
    }
}
