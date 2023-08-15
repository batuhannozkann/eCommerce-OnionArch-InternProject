using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Address;
using eCommerce.Domain.DTOs.Categories;
using eCommerce.Domain.DTOs.Order;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.DTOs.ShippingCompanies;
using eCommerce.Domain.DTOs.Shippings;
using eCommerce.Domain.DTOs.Users;
using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface IAdminService
    { 

        IDataResult<List<AddressDto>> GetAllAddress();
        public List<MoneyUnit> GetTcmb();
        IDataResult<List<CategoryDto>> GetAllCategory();
        IDataResult<List<OrderDto>> GetAllOrder();
        IDataResult<List<ProductDto>> GetAllProduct();
        IDataResult<List<ShippingCompanyDto>> GetAllShippingCompany();
        IDataResult<List<ShippingDto>> GetAllShipping();
        IDataResult<List<UserDto>> GetAllUser(); 



    }
}
