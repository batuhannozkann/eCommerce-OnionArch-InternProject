using eCommerce.Domain.DTOs.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Validators.Products
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotEmpty().Must(x => x >= 0).WithMessage("Price must not be negative");
            
        }
    }
}
