using AutoMapper;
using com.sun.xml.@internal.bind.v2.model.core;
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

        public Task<IDataResult<ShippingCompanyDto>> GetSingleAsync(Expression<Func<ShippingCompany, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ShippingCompanyDto>> GetWhere(Expression<Func<ShippingCompany, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ShippingCompanyDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<ShippingCompany, bool>> method)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ShippingCompanyDto>> Remove(long id)
        {
            ShippingCompany shippingCompany = await _shippingCompanyRepository.GetByIdAsync(id);
            if (shippingCompany == null) return new ErrorDataResult<ShippingCompanyDto>("Shipping company has not found", 400);
            await _shippingCompanyRepository.Remove(id);
            await _unitOfWork.CommitAsync();
            ShippingCompanyDto shippingCompanyDto = _mapper.Map<ShippingCompanyDto>(shippingCompany);
            return new SuccessDataResult<ShippingCompanyDto>(shippingCompanyDto, 200);


        }

        public Task<IDataResult<List<ShippingCompanyDto>>> RemoveRange(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ShippingCompanyDto>> Update(ShippingCompanyDto model)
        {
            ShippingCompany shippingCompany = await _shippingCompanyRepository.GetByIdAsync(model.Id);
            if (shippingCompany == null) return new ErrorDataResult<ShippingCompanyDto>("Shipping company has not found", 400);
            shippingCompany.Address = model.Address ?? shippingCompany.Address;
            shippingCompany.Phone=model.Phone??shippingCompany.Phone;
            shippingCompany.Email = model.Email ?? shippingCompany.Email;
            shippingCompany.Code=model.Code??shippingCompany.Code;
            shippingCompany.Description=model.Description?? shippingCompany.Description;
            shippingCompany.Name = model.Name ?? shippingCompany.Name;
            shippingCompany.WebSite = model.WebSite ?? shippingCompany.WebSite;
            ShippingCompanyDto shippingCompanyDto = _mapper.Map<ShippingCompanyDto>(shippingCompany);
            return new SuccessDataResult<ShippingCompanyDto>(shippingCompanyDto, 200);
        }
    }
}
