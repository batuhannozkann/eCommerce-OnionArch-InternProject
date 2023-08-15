using eCommerce.Domain.DTOs.Order;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Validators.Orders
{
    public class ProductOrderCreateDtoValidator:AbstractValidator<ProductOrderCreateDto>
    {
        public ProductOrderCreateDtoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().NotNull();
            RuleFor(x=>x.Quantity).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
        }
    }
}
