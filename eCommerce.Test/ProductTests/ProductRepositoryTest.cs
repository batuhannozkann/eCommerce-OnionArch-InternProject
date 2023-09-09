using eCommerce.Domain.Entities;
using eCommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Test;

public class ProductRepositoryTest
{
    private readonly DbContextOptions<eCommerceDbContext> _contextOptions;

    public ProductRepositoryTest()
    {
        _contextOptions = new DbContextOptionsBuilder<eCommerceDbContext>()
            .UseNpgsql
                ("User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=eCommerceDb;")
            .Options;
    }

    [Fact]
    public void GetAll_ExecuteContext_ReturnProductList()
    {
        using (eCommerceDbContext context = new eCommerceDbContext(_contextOptions))
        {
            var Products = context.Products.ToList();
            Assert.IsAssignableFrom<IEnumerable<Product>>(Products);
            Assert.NotEmpty(Products);
            Assert.NotNull(Products);
            Assert.Equal(expected:1,actual:Products.FirstOrDefault().Id);
        }
    }
}