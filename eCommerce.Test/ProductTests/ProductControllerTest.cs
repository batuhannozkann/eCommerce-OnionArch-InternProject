using eCommerce.Application.Services;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Utilities.Results;
using eCommerce.WebAPI.Controllers;
using ikvm.extensions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace eCommerce.Test;

public class ProductControllerTest
{
    private readonly Mock<IProductService> _mockService;
    private readonly ProductController _controller;
    private readonly IDataResult<List<ProductDto>> _dataResult;

    public ProductControllerTest()
    {
        _mockService = new Mock<IProductService>();
        _controller = new ProductController(_mockService.Object);
        _dataResult = new SuccessDataResult<List<ProductDto>>(data: new List<ProductDto>()
        {
            new ProductDto()
            {
                Id = 1, Name = "Phone", Price = 100000, Stock = 500, Description = "it provide to create communication"
            },
            new ProductDto() { Id = 2, Name = "TV", Price = 50000, Stock = 400, Description = "Television" }
        }, statusCode: 200);
    }

    [Fact]
    public void GetAll_ActionExecutes_ReturnOkResultWithProducts()
    {
         _mockService.Setup(x => x.GetAll()).Returns(_dataResult);
         var result = _controller.GetAll();
         var okResult = Assert.IsType<OkObjectResult>(result);
         var returnProducts = Assert.IsAssignableFrom<IDataResult<List<ProductDto>>>(okResult.Value);
         Assert.Equal<int>(2,returnProducts.Data.Count);
         
    }
    
}