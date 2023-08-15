using AutoMapper;
using com.sun.jdi.request;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Address;
using eCommerce.Domain.DTOs.Categories;
using eCommerce.Domain.DTOs.Order;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.DTOs.ShippingCompanies;
using eCommerce.Domain.DTOs.Shippings;
using eCommerce.Domain.DTOs.Users;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Identity;
using eCommerce.Infrastructure.Utilities.Results;
using javax.jws;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace eCommerce.Persistence.Services
{
    public class AdminService : IAdminService
        
    {
        private IAddressRepository _addressRepository;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        private ICategoryRepository _categoryRepository;
        private IShippingCompanyRepository _shippingCompanyRepository;
        private IShippingRepository _shippingRepository;
        private UserManager<AppUser> _userManager;
        private IMapper _mapper;

        public AdminService(IMapper mapper,IAddressRepository addressRepository, IProductRepository productRepository, IOrderRepository orderRepository, ICategoryRepository categoryRepository, IShippingCompanyRepository shippingCompanyRepository, IShippingRepository shippingRepository, UserManager<AppUser> userManager)
        {
            _addressRepository = addressRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _categoryRepository = categoryRepository;
            _shippingCompanyRepository = shippingCompanyRepository;
            _shippingRepository = shippingRepository;
            _userManager = userManager;
            _mapper=mapper;
        }

        public IDataResult<List<AddressDto>> GetAllAddress()
        {
            List<Address> addresses = _addressRepository.GetAll().OrderBy(x => x.Id).ToList();
            if (addresses == null || addresses.Count == 0) return new ErrorDataResult<List<AddressDto>>("Address has not found", 400);
            List<AddressDto> addressDtos = _mapper.Map<List<Address>, List<AddressDto>>(addresses);
            return new SuccessDataResult<List<AddressDto>>(addressDtos, 200);
        }

        public IDataResult<List<CategoryDto>> GetAllCategory()
        {
            List<Category> categories = _categoryRepository.GetAll().OrderBy(x => x.Id).ToList();
            List<CategoryDto> categoryDtos = _mapper.Map<List<Category>, List<CategoryDto>>(categories);
            return new SuccessDataResult<List<CategoryDto>>(categoryDtos, 200);
        }

        public IDataResult<List<OrderDto>> GetAllOrder()
        {
            List<Order> orders = _orderRepository.GetAll().OrderBy(x => x.Id).ToList();
            if (orders.Count == 0 || orders == null) return new ErrorDataResult<List<OrderDto>>("Any order has not found", 400);
            List<OrderDto> orderDtos = _mapper.Map<List<Order>, List<OrderDto>>(orders);
            return new SuccessDataResult<List<OrderDto>>(orderDtos, 200);
        }

        public IDataResult<List<ProductDto>> GetAllProduct()
        {
            List<Product> products = _productRepository.GetAll().OrderBy(x => x.Id).ToList();
            List<ProductDto> productsDto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return new SuccessDataResult<List<ProductDto>>(productsDto, 200);
        }

        public IDataResult<List<ShippingDto>> GetAllShipping()
        {
            List<Shipping> shippings = _shippingRepository.GetAll().OrderBy(x => x.Id).ToList();
            if (shippings.Count == 0 && shippings == null) return new ErrorDataResult<List<ShippingDto>>("Any shipping has not found", 400);
            List<ShippingDto> shippingDtos = _mapper.Map<List<Shipping>, List<ShippingDto>>(shippings);
            return new SuccessDataResult<List<ShippingDto>>(shippingDtos, 200);
        }

        public IDataResult<List<ShippingCompanyDto>> GetAllShippingCompany()
        {
            List<ShippingCompany> shippingCompanies = _shippingCompanyRepository.GetAll().OrderBy(x => x.Id).ToList();
            if (shippingCompanies.Count == 0 || shippingCompanies == null) return new ErrorDataResult<List<ShippingCompanyDto>>("Any shipping company has not found", 400);
            List<ShippingCompanyDto> shippingCompanyDtos = _mapper.Map<List<ShippingCompany>, List<ShippingCompanyDto>>(shippingCompanies);
            return new SuccessDataResult<List<ShippingCompanyDto>>(shippingCompanyDtos, 200);
        }

        public IDataResult<List<UserDto>> GetAllUser()
        {
            List<AppUser> users = _userManager.Users.ToList();
            if (users.Count == 0 || users == null) return new ErrorDataResult<List<UserDto>>("Any user has not found", 400);
            List<UserDto> userDtos = _mapper.Map<List<AppUser>, List<UserDto>>(users);
            return new SuccessDataResult<List<UserDto>>(userDtos, 200);
        }
        
        public List<MoneyUnit> GetTcmb()
        {
            string dolar = "https://www.tcmb.gov.tr/kurlar/today.xml";
            XDocument documents = XDocument.Load(dolar);
            XmlDocument xmlDocument = new();
            xmlDocument.Load(dolar);
            List<MoneyUnit> moneyUnits = new();
            foreach(XElement document in documents.Descendants("Currency"))
            {
                moneyUnits.Add(new MoneyUnit
                {
                    Isim = document.Attribute("Kod").Value,
                    BanknoteSelling = Convert.ToDecimal(document.Element("BanknoteSelling").Value),
                    BanknoteBuying=document.Element("BanknoteBuying").Value,
                    ForexBuying=document.Element("ForexBuying").Value,
                    ForexSelling=document.Element("ForexSelling").Value,
                    CurrencyName = document.Element("CurrencyName").Value





                }) ;
            }
            

            return moneyUnits;
        }
    }
}
