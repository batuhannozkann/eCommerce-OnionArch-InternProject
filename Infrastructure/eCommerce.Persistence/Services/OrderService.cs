using AutoMapper;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.UnitOfWork;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.Constants;
using eCommerce.Domain.DTOs.Categories;
using eCommerce.Domain.DTOs.Order;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Identity;
using eCommerce.Infrastructure.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IAddressRepository _addressRepository;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IProductRepository productRepository;
        private UserManager<AppUser> _userManager;

        public OrderService(IOrderRepository orderRepository, IAddressRepository addressRepository, IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository, UserManager<AppUser> userManager)
        {
            _orderRepository = orderRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            this.productRepository = productRepository;
            _userManager = userManager;
        }

        public async Task<IDataResult<OrderDto>> AddAsync(OrderCreateDto model)
        {
            List<ProductOrder> productOrders = new List<ProductOrder>();
            Order order = _mapper.Map<Order>(model);
            foreach(var i in model.Products)
            {
                productOrders.Add(new ProductOrder { OrderId=order.Id,ProductId=i.ProductId,ProductQuantity=i.Quantity});
                order.Price += productRepository.GetByIdAsync(i.ProductId).Result.Price;
            }
            order.Tax = order.Price * Convert.ToDecimal(Tax.KDV);
            order.TotalPrice = order.Price + order.Tax;
            order.ProductOrders = productOrders;
            order.ProductCount = productOrders.Select(x=>x.ProductQuantity).Sum();
            order.Address =await _addressRepository.GetByIdAsync(model.AddressId);
            if (order.Address == null) return new ErrorDataResult<OrderDto>("Address has not found", 400);
            order.User = await _userManager.FindByIdAsync(model.UserId);
            if (order.Address == null) return new ErrorDataResult<OrderDto>("User has not found", 400);
            Order addedOrder = await _orderRepository.AddAsync(order);
            _unitOfWork.Commit();
            OrderDto orderDto = _mapper.Map<OrderDto>(addedOrder);
            return new SuccessDataResult<OrderDto>(orderDto, 200);
            
        }

        public Task<IDataResult<List<OrderDto>>> AddRangeAsync(List<OrderCreateDto> models)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OrderDto>> GetAll()
        {
            List<Order> orders = _orderRepository.GetAll().Where(x=>x.IsDeleted==false).ToList();
            if(orders.Count == 0||orders==null) return new ErrorDataResult<List<OrderDto>>("Any order has not found", 400);
            List<OrderDto> orderDtos = _mapper.Map<List<Order>, List<OrderDto>>(orders);
            return new SuccessDataResult<List<OrderDto>>(orderDtos, 200);
        }

        public IDataResult<List<OrderDto>> GetAllAsNoTrackingWithIdentityResolution()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<OrderDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<OrderDto>> GetSingleAsync(Expression<Func<Order, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OrderDto>> GetWhere(Expression<Func<Order, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OrderDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<Order, bool>> method)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<OrderDto>> Remove(long id)
        {
            Order order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return new ErrorDataResult<OrderDto>("Order has not found", 400);
            OrderDto orderDto = _mapper.Map<OrderDto>(order);
            await _orderRepository.Remove(id);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<OrderDto>(orderDto, 200);
            
            
        }

        public Task<IDataResult<List<OrderDto>>> RemoveRange(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<OrderDto>> Update(OrderDto model)
        {
            Order order = await _orderRepository.GetByIdAsync(model.Id);
            List<ProductOrder> productOrders = new();
            if (order == null) return new ErrorDataResult<OrderDto>("Order has not found", 400);
            AppUser appUser = _mapper.Map<AppUser>(model.User);
            order.User = appUser ?? order.User;
            Address address = _mapper.Map<Address>(model.Address);
            order.Address = address ?? order.Address;
            foreach(var i in model.Products)
            {
                productOrders.Add(new ProductOrder { ProductId = i.Product.Id, OrderId = model.Id });
                order.Price += productRepository.GetByIdAsync(i.Product.Id).Result.Price;
            }
            if (productOrders != null)
            {
                order.ProductOrders = productOrders ?? order.ProductOrders;
                order.ProductCount = productOrders.Select(x => x.ProductQuantity).Sum();
                order.Tax = order.Price * Convert.ToDecimal(Tax.KDV);
                order.TotalPrice = order.Price + order.Tax;
            }
            _orderRepository.Update(order);
            _unitOfWork.CommitAsync();
            OrderDto orderDto = _mapper.Map<OrderDto>(order);
            return new SuccessDataResult<OrderDto>(orderDto, 200);
        }

    }
}
