using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Categories;
using eCommerce.Domain.DTOs.Order;
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
    public interface IOrderService
    {
        Task<IDataResult<List<OrderDto>>> AddRangeAsync(List<OrderCreateDto> models);
        IDataResult<List<OrderDto>> GetAll();
        Task<IDataResult<OrderDto>> GetByIdAsync(long id);
        Task<IDataResult<OrderDto>> GetSingleAsync(Expression<Func<Order, bool>> method);
        IDataResult<List<OrderDto>> GetWhere(Expression<Func<Order, bool>> method);
        Task<IDataResult<OrderDto>> AddAsync(OrderCreateDto model);
        Task<IDataResult<OrderDto>> Remove(long id);
        Task<IDataResult<List<OrderDto>>> RemoveRange(List<int> ids);
        Task<IDataResult<OrderDto>> Update(OrderDto model);
        public IDataResult<List<OrderDto>> GetAllAsNoTrackingWithIdentityResolution();
        public IDataResult<List<OrderDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<Order, bool>> method);
    }
}
