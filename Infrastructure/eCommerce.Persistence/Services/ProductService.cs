using AutoMapper;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.Utilities.Results;
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
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<ProductCreateDto>> AddAsync(ProductCreateDto model)
        {
            Product product = _mapper.Map<Product>(model);
            Product addedProduct = await _productRepository.AddAsync(product);
                ProductCreateDto productCreateDto = _mapper.Map<ProductCreateDto>(addedProduct);
                return new SuccessDataResult<ProductCreateDto>(productCreateDto,"Product has successfully created",201);
        }

        public async Task<IDataResult<List<ProductCreateDto>>> AddRangeAsync(List<ProductCreateDto> models)
        {
            List<Product> products = _mapper.Map<List<ProductCreateDto>,List<Product>>(models);
            await _productRepository.AddRangeAsync(products);
            
                //Exception throw
                return new SuccessDataResult<List<ProductCreateDto>>(models,200);
        }

        public IDataResult<List<ProductDto>> GetAll()
        {
            List<Product> products = _productRepository.GetAll().Where(x => x.IsDeleted == false).ToList();
            List<ProductDto> productsDto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return new SuccessDataResult<List<ProductDto>>(productsDto, 200);
        }

        public IDataResult<List<ProductDto>> GetAllAsNoTrackingWithIdentityResolution()
        {
            List<Product> products = _productRepository.GetAllAsNoTrackingWithIdentityResolution().ToList();
            List<ProductDto> productDtos = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return new SuccessDataResult<List<ProductDto>>(productDtos, 200);
        }
        public IDataResult<List<ProductWithCategoryDto>> GetAllWithCategory()
        {
            List<Product> products = _productRepository.GetAllWithCategory().ToList();
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
            return new ErrorDataResult<ProductDto>(new List<string> { "Product is not found" }, 400);
           
        }

        public async Task<IDataResult<ProductDto>> GetSingleAsync(Expression<Func<Product, bool>> method)
        {
            Product product = await _productRepository.GetSingleAsync(method);
            if (!product.IsDeleted)
            {
                ProductDto productDto = _mapper.Map<ProductDto>(product);
                return new SuccessDataResult<ProductDto>(productDto, 200);
            }
            return new ErrorDataResult<ProductDto>(new List<string> { "Product is not found" }, 400);
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
            _productRepository.Remove(id);
            return new SuccessDataResult<ProductDto>(productDto, 200);

        }

        public async Task<IDataResult<List<ProductDto>>> RemoveRange(List<int> ids)
        {
            List<Product> products = new();
            foreach(int id in ids)
            {
                products.Add(await _productRepository.GetByIdAsync(id));
                _productRepository.Remove(id);
            }
            List<ProductDto> productDtos = _mapper.Map<List<Product>,List<ProductDto>>(products);
            return new SuccessDataResult<List<ProductDto>>(productDtos, 200);
        }

        public async Task<IDataResult<ProductDto>> Update(ProductDto model)
        {
            Product changedProduct = _mapper.Map<Product>(model);
            _productRepository.Update(changedProduct);
            ProductDto productDto = _mapper.Map<ProductDto>(changedProduct);
            return new SuccessDataResult<ProductDto>(productDto, 200);
        }
    }
}
