using AutoMapper;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.UnitOfWork;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.Entities;
using eCommerce.Persistence.Repositories;
using eCommerce.Persistence.Services;
using Moq;

namespace eCommerce.Test;

public class ProductServiceTest
{
    private readonly ProductService _productService;
    private readonly Mock<IProductRepository> _productRepository;
    private readonly Mock<ICategoryRepository> _categoryRepoitory;
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly List<Product> _products;
    private readonly List<Category> _categories;
    
    

    public ProductServiceTest()
    {
        _productRepository = new Mock<IProductRepository>();
        _categoryRepoitory = new Mock<ICategoryRepository>();
        _mapper = new Mock<IMapper>();
        _unitOfWork = new Mock<IUnitOfWork>();
        _productService = new ProductService(_productRepository.Object, _categoryRepoitory.Object, _unitOfWork.Object,
            _mapper.Object);
        _products = new List<Product>()
        {
            new Product()
            {
                Id = 1, Name = "IPhone", Price = 100000, Stock = 500, Description = "it provide to create communication"
            },
            new Product() { Id = 2, Name = "Samsung Led TV", Price = 50000, Stock = 400, Description = "Television" }
        };
        _categories = new List<Category>()
        {
            new Category() { Id = 1, Name = "Phone" },
            new Category() {Id = 2,Name = "Television"}
        };
    }

    [Fact]
    public void GetAll_FunctionExecute_ReturnDataResult()
    {
        _productRepository.Setup(x => x.GetAll()).Returns(_products.AsQueryable());
        var result = _productService.GetAll();
        Assert.IsAssignableFrom<IDataResult<List<ProductDto>>>(result);
    }
}