using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Address;
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
    public interface IAddressService
    {
        IDataResult<List<AddressDto>> AddRangeAsync(List<AddressCreateDto> models);
        IDataResult<List<AddressDto>> GetAll();
        IDataResult<List<AddressDto>> GetAllWithProduct();
        Task<IDataResult<AddressDto>> GetByIdAsync(long id);
        Task<IDataResult<AddressDto>> GetSingleAsync(Expression<Func<Address, bool>> method);
        IDataResult<List<AddressDto>> GetWhere(Expression<Func<Address, bool>> method);
        Task<IDataResult<AddressDto>> AddAsync(AddressCreateDto model);
        Task<IDataResult<AddressDto>> Remove(long id);
        Task<IDataResult<List<AddressDto>>> RemoveRange(List<int> ids);
        Task<IDataResult<AddressDto>> Update(AddressUpdateDto model);
        public IDataResult<List<AddressDto>> GetAllAsNoTrackingWithIdentityResolution();
        public IDataResult<List<AddressDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<Address, bool>> method);
    }
}
