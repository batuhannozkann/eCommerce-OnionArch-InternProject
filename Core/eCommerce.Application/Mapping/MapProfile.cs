using AutoMapper;
using eCommerce.Domain.DTOs.Categories;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.Entities;
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
        }
    }
}
