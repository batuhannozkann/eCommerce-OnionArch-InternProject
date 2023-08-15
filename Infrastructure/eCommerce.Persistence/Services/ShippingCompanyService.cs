using AutoMapper;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.UnitOfWork;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Address;
using eCommerce.Domain.DTOs.ShippingCompanies;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Services
{
    public class ShippingCompanyService : IShippingCompanyService
    {
        private IShippingCompanyRepository _shippingCompanyRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ShippingCompanyService(IShippingCompanyRepository shippingCompanyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _shippingCompanyRepository = shippingCompanyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<ShippingCompanyDto>> AddAsync(ShippingCompanyCreateDto model)
        {
            ShippingCompany shippingCompany = _mapper.Map<ShippingCompany>(model);
            ShippingCompany addedShippingCompany =await  _shippingCompanyRepository.AddAsync(shippingCompany);
            await _unitOfWork.CommitAsync();
            ShippingCompanyDto shippingCompanyDto = _mapper.Map<ShippingCompanyDto>(addedShippingCompany);
            return new SuccessDataResult<ShippingCompanyDto>(shippingCompanyDto, 200);
        }

        public IDataResult<List<ShippingCompanyDto>> AddRangeAsync(List<ShippingCompanyCreateDto> models)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ShippingCompanyDto>> GetAll()
        {
            List<ShippingCompany> shippingCompanies = _shippingCompanyRepository.GetAll().Where(x=>x.IsDeleted==false).ToList();
            if (shippingCompanies.Count == 0 || shippingCompanies == null) return new ErrorDataResult<List<ShippingCompanyDto>>("Any shipping company has not found", 400);
            List<ShippingCompanyDto> shippingCompanyDtos = _mapper.Map<List<ShippingCompany>, List<ShippingCompanyDto>>(shippingCompanies);
            return new SuccessDataResult<List<ShippingCompanyDto>>(shippingCompanyDtos,200);
        }

        public IDataResult<List<ShippingCompanyDto>> GetAllAsNoTrackingWithIdentityResolution()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ShippingCompanyDto>> GetAllWithProduct()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ShippingCompanyDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ShippingCompanyDto>> GetSingleAsync(Expression<Func<Address, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ShippingCompanyDto>> GetWhere(Expression<Func<Address, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ShippingCompanyDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<Address, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ShippingCompanyDto>> Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<ShippingCompanyDto>>> RemoveRange(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ShippingCompanyDto>> Update(AddressDto model)
        {
            throw new NotImplementedException();
        }
    }
}
