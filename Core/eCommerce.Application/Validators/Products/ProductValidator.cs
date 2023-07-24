using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Validators.Products
{
    public class ProductValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Product name can not be null or empty");
        }
    }
}
