using AutoMapper;
using eCommerce.Domain.DTOs.Address;
using eCommerce.Domain.DTOs.Categories;
using eCommerce.Domain.DTOs.Order;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.DTOs.ShippingCompanies;
using eCommerce.Domain.DTOs.Shippings;
using eCommerce.Domain.DTOs.Token;
using eCommerce.Domain.DTOs.Users;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Common;
using eCommerce.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductCreateDto, Product>().ReverseMap();
            CreateMap<ProductDto,Product>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ProductCategory, CategoryDto>().ForMember(x=>x.Name,y=>y.MapFrom(y=>y.Category.Name)).ReverseMap();
            CreateMap<Product, ProductWithCategoryDto>()
                .ForMember(x => x.Categories, y => y.MapFrom(x=>x.ProductCategories))
                .ReverseMap();
            CreateMap<ProductWithCategoryDto, Product>().ForMember(x => x.ProductCategories, y => y.MapFrom(y => y.Categories));
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryCreateDto,Category>().ReverseMap();
            CreateMap<Category, CategoryWithProductsDto>().ForMember(x=>x.Products,y=>y.MapFrom(y=>y.ProductCategories.Select(x=>x.Product))).ReverseMap();
            CreateMap<CreateUserDto, AppUser>().ReverseMap();
            CreateMap<UserRefreshToken,RefreshTokenDto>().ReverseMap();
            CreateMap<OrderCreateDto, Order>().ReverseMap();
            CreateMap<Order,OrderDto>().ForMember(x=>x.Products,y=>y.MapFrom(y=>y.ProductOrders))
                .ReverseMap();
            CreateMap<ProductOrder, ProductOrderDto>().ForMember(x => x.Product, y => y.MapFrom(x => x.Product))
                .ForMember(x=>x.Quantity,y=>y.MapFrom(y=>y.ProductQuantity)).ReverseMap();
            CreateMap<ShippingProduct, ShippingProductDto>().ForMember(x => x.Product, y => y.MapFrom(y => y.Product))
                .ForMember(x => x.Quantity, y => y.MapFrom(y => y.ProductQuantity))
                .ReverseMap();
            CreateMap<Order, OnlyOrderDto>().ForMember(x => x.Products, y => y.MapFrom(y => y.ProductOrders))
                .ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<AddressNoUserDto, Address>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<AddressCreateDto, Address>().ReverseMap();
            CreateMap<AppUser,UserWithRoleDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
            CreateMap<ShippingCreateDto, Shipping>().ReverseMap();
            CreateMap<Shipping,ShippingDto>().ReverseMap();
            CreateMap<ShippingCompanyCreateDto,ShippingCompany>().ReverseMap();
            CreateMap<ShippingCompanyDto, ShippingCompany>().ReverseMap();
        }
    }
}
