using AutoMapper;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.UnitOfWork;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Address;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Identity;
using eCommerce.Infrastructure.Utilities.Results;
using eCommerce.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;
        private UserManager<AppUser> _userManager;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public AddressService(IAddressRepository addressRepository, UserManager<AppUser> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _addressRepository = addressRepository;
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<AddressDto>> AddAsync(AddressCreateDto model)
        {
            Address address = _mapper.Map<Address>(model);
            address.User = await _userManager.FindByIdAsync(model.UserId);
            if (address.User == null) return new ErrorDataResult<AddressDto>("User has not found", 400);
            Address addedAddress = await _addressRepository.AddAsync(address);
            await _unitOfWork.CommitAsync();
            AddressDto addressDto = _mapper.Map<AddressDto>(addedAddress);
            return new SuccessDataResult<AddressDto>(addressDto, 200);
        }

        public IDataResult<List<AddressDto>> AddRangeAsync(List<AddressCreateDto> models)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<AddressDto>> GetAll()
        {
            List<Address> addresses = _addressRepository.GetAll().Where(x=>x.IsDeleted==false).ToList();
            if (addresses == null || addresses.Count == 0) return new ErrorDataResult<List<AddressDto>>("Address has not found", 400);
            List<AddressDto> addressDtos =_mapper.Map<List<Address>,List<AddressDto>>(addresses);
            return new SuccessDataResult<List<AddressDto>>(addressDtos, 200);
            
        }

        public IDataResult<List<AddressDto>> GetAllAsNoTrackingWithIdentityResolution()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<AddressDto>> GetAllWithProduct()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<AddressDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<AddressDto>> GetSingleAsync(Expression<Func<Address, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<AddressDto>> GetWhere(Expression<Func<Address, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<AddressDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<Address, bool>> method)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<AddressDto>> Remove(long id)
        {
            Address address = await _addressRepository.GetByIdAsync(id);
            if (address == null) return new ErrorDataResult<AddressDto>("Address has not found", 400);
            _addressRepository.Remove(address);
            await _unitOfWork.CommitAsync();
            AddressDto addressDto = _mapper.Map<AddressDto>(address);
            return new SuccessDataResult<AddressDto>(addressDto, 200);
        }

        public Task<IDataResult<List<AddressDto>>> RemoveRange(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<AddressDto>> Update(AddressUpdateDto model)
        {
            Address address = await _addressRepository.GetByIdAsync(model.Id);
            address.FullAddress = model.FullAddress ?? address.FullAddress;
            address.Description = model.Description ?? address.Description;
            address.District=model.District ?? address.District;
            address.City=model.City ?? address.City;
            address.Country=model.Country ?? address.Country;
            AppUser appUser = await _userManager.FindByIdAsync(model.UserId);
            address.User = appUser ?? address.User;
            _addressRepository.Update(address);
            await _unitOfWork.CommitAsync();
            AddressDto addressDto = _mapper.Map<AddressDto>(address);
            return new SuccessDataResult<AddressDto>(addressDto, 200);
        }
    }
}
