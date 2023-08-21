using AutoMapper;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.UnitOfWork;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.Constants;
using eCommerce.Domain.DTOs.Shippings;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Common;
using eCommerce.Domain.Identity;
using eCommerce.Infrastructure.Utilities;
using eCommerce.Infrastructure.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Services
{
    public class ShippingService : IShippingService
        
    {
        private IShippingRepository _shippingRepository;
        private IMapper _mapper;
        private IOrderRepository _orderRepository;
        private UserManager<AppUser> _userManager;
        private IAddressRepository _addressRepository;
        private IShippingCompanyRepository _shippingCompanyRepository;
        private IUnitOfWork _unitOfWork;

        public ShippingService(IShippingRepository shippingRepository, IMapper mapper, IOrderRepository orderRepository, UserManager<AppUser> userManager, IAddressRepository addressRepository, IShippingCompanyRepository shippingCompanyRepository, IUnitOfWork unitOfWork)
        {
            _shippingRepository = shippingRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _userManager = userManager;
            _addressRepository = addressRepository;
            _shippingCompanyRepository = shippingCompanyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<ShippingDto>> AddAsync(ShippingCreateDto model)
        {
            Shipping shipping = _mapper.Map<Shipping>(model);
            List<ShippingProduct> shippingProducts = new List<ShippingProduct>();
            Order order =_orderRepository.GetAll().Where(x => x.Id == model.OrderId).FirstOrDefault();
            if (order == null) return new ErrorDataResult<ShippingDto>("Order has not found", 400);
            order.Shipping = shipping;
            shipping.Address = order.Address;
            shipping.Order = order;
            shipping.User = order.User;
            if(shipping.User == null) return new ErrorDataResult<ShippingDto>("User has not found", 400);
            shipping.ShippingDate = DateTime.UtcNow;
            shipping.ShippingCompany = await _shippingCompanyRepository.GetByIdAsync(model.ShippingCompanyId);
            foreach(var i in order.ProductOrders)
            {
                shippingProducts.Add(new ShippingProduct { ProductId = i.ProductId ,ShippingId=shipping.Id,ProductQuantity=i.ProductQuantity});
            }
            shipping.Destination = $"{order.User.FirstName} {order.User.LastName}";
            shipping.Sender = "eCommerceCompany";
            if(order.TotalPrice>150)
            {
                shipping.Price = 30;
            }
            else
            {
                shipping.Price = 0;
            }
            shipping.ShippingDate = DateTime.Now;
            shipping.ShippingProducts = shippingProducts;
            
            string trackingNumber = $"{shipping.ShippingCompany.Code}{order.Id}{order.User.FirstName.Substring(0, 1).ToUpper()}{order.User.LastName.Substring(0, 1).ToUpper()}{Guid.NewGuid().ToString().Substring(0,6)}";
            shipping.TrackingNumber = NameOperations.CharacterRegulatory(trackingNumber);
            await _shippingRepository.AddAsync(shipping);
            await _unitOfWork.CommitAsync();
            ShippingDto shippingDto = _mapper.Map<ShippingDto>(shipping);
            return new SuccessDataResult<ShippingDto>(shippingDto, 200);
        }

        public IDataResult<List<ShippingDto>> AddRangeAsync(List<ShippingCreateDto> models)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ShippingDto>> GetAll()
        {
            List<Shipping> shippings = _shippingRepository.GetAll().Where(x=>x.IsDeleted==false).ToList();
            if (shippings.Count == 0 && shippings == null) return new ErrorDataResult<List<ShippingDto>>("Any shipping has not found",400);
            List<ShippingDto> shippingDtos = _mapper.Map<List<Shipping>, List<ShippingDto>>(shippings);
            return new SuccessDataResult<List<ShippingDto>>(shippingDtos, 200);
            
        }

        public IDataResult<List<ShippingDto>> GetAllAsNoTrackingWithIdentityResolution()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ShippingDto>> GetAllWithProduct()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ShippingDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<ShippingDto> GetShippingByTrackingNumber(string trackingNumber)
        {
            Shipping shipping = _shippingRepository.GetAll().Where(x=>x.TrackingNumber== trackingNumber).FirstOrDefault();
            if (shipping == null) return new ErrorDataResult<ShippingDto>("Shipping has not found", 400);
            ShippingDto shippingDto = _mapper.Map<ShippingDto>(shipping);
            return new SuccessDataResult<ShippingDto>(shippingDto, 200);
        }

        public Task<IDataResult<ShippingDto>> GetSingleAsync(Expression<Func<Shipping, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ShippingDto>> GetWhere(Expression<Func<Shipping, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ShippingDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<Shipping, bool>> method)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ShippingDto>> RemoveAsync(long id)
        {
            Shipping shipping =await _shippingRepository.GetByIdAsync(id);
            if (shipping == null) return new ErrorDataResult<ShippingDto>("Shipping has not found", 400);
            _shippingRepository.Remove(shipping);
            await _unitOfWork.CommitAsync();
            ShippingDto removedShippingDto = _mapper.Map<ShippingDto>(shipping);
            return new SuccessDataResult<ShippingDto>(removedShippingDto, 200);
        }

        public Task<IDataResult<List<ShippingDto>>> RemoveRange(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ShippingDto>> Update(ShippingUpdateDto model)
        {
            Shipping shipping = await _shippingRepository.GetByIdAsync(model.Id);
            if (shipping == null) return new ErrorDataResult<ShippingDto>("Shipping has not found", 400);
            shipping.State = model.State ?? shipping.State;
            shipping.Recipient = model.Recipient??shipping.Recipient;
            shipping.Description = model.Description ?? shipping.Description;
            _shippingRepository.Update(shipping);
            await _unitOfWork.CommitAsync();
            ShippingDto shippingDto = _mapper.Map<ShippingDto>(shipping);
            return new SuccessDataResult<ShippingDto>(shippingDto, 200);
        }
    }
}
