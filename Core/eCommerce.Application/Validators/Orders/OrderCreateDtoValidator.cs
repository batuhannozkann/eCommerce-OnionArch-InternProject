using eCommerce.Domain.DTOs.Order;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Validators.Orders
{
    public class OrderCreateDtoValidator:AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator()
        {
            RuleFor(x => x.AddressId).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x=>x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.Products).NotEmpty().NotNull();
        }
    }
}
