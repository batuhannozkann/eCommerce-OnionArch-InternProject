using eCommerce.Domain.DTOs.Order;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Validators.Orders
{
    public class OrderDtoValidator:AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
                RuleFor(x=>x.Address).NotEmpty();
            RuleFor(x => x.User).NotEmpty().NotNull();
            RuleFor(x => x.TotalPrice).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x=>x.Products).Null().NotEmpty();
        }
    }
}
