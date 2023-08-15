using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Address;
using eCommerce.Domain.DTOs.Shippings;
using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface IShippingService
    {
        IDataResult<List<ShippingDto>> AddRangeAsync(List<ShippingCreateDto> models);
        IDataResult<List<ShippingDto>> GetAll();
        IDataResult<List<ShippingDto>> GetAllWithProduct();
        Task<IDataResult<ShippingDto>> GetByIdAsync(long id);
        Task<IDataResult<ShippingDto>> GetSingleAsync(Expression<Func<Shipping, bool>> method);
        IDataResult<List<ShippingDto>> GetWhere(Expression<Func<Shipping, bool>> method);
        Task<IDataResult<ShippingDto>> AddAsync(ShippingCreateDto model);
        Task<IDataResult<ShippingDto>> Remove(long id);
        Task<IDataResult<List<ShippingDto>>> RemoveRange(List<int> ids);
        Task<IDataResult<ShippingDto>> Update(ShippingUpdateDto model);
        IDataResult<ShippingDto> GetShippingByTrackingNumber(string trackingNumber);
        public IDataResult<List<ShippingDto>> GetAllAsNoTrackingWithIdentityResolution();
        public IDataResult<List<ShippingDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<Shipping, bool>> method);
    }
}
