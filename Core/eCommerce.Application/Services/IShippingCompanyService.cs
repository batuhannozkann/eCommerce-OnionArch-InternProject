using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Address;
using eCommerce.Domain.DTOs.ShippingCompanies;
using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface IShippingCompanyService
    {
        IDataResult<List<ShippingCompanyDto>> AddRangeAsync(List<ShippingCompanyCreateDto> models);
        IDataResult<List<ShippingCompanyDto>> GetAll();
        IDataResult<List<ShippingCompanyDto>> GetAllWithProduct();
        Task<IDataResult<ShippingCompanyDto>> GetByIdAsync(long id);
        Task<IDataResult<ShippingCompanyDto>> GetSingleAsync(Expression<Func<ShippingCompany, bool>> method);
        IDataResult<List<ShippingCompanyDto>> GetWhere(Expression<Func<ShippingCompany, bool>> method);
        Task<IDataResult<ShippingCompanyDto>> AddAsync(ShippingCompanyCreateDto model);
        Task<IDataResult<ShippingCompanyDto>> Remove(long id);
        Task<IDataResult<List<ShippingCompanyDto>>> RemoveRange(List<int> ids);
        Task<IDataResult<ShippingCompanyDto>> Update(ShippingCompanyDto model);
        public IDataResult<List<ShippingCompanyDto>> GetAllAsNoTrackingWithIdentityResolution();
        public IDataResult<List<ShippingCompanyDto>> GetWhereAsNoTrackingWithIdentityResolution(Expression<Func<ShippingCompany, bool>> method);
    }
}
