using eCommerce.Domain.DTOs.Address;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Validators.Address
{
    public class AddressCreateDtoValidator:AbstractValidator<AddressCreateDto>
    {
        public AddressCreateDtoValidator()
        {
            RuleFor(x=>x.UserId).NotEmpty();
            RuleFor(x=>x.FullAddress).NotEmpty();
            RuleFor(x=>x.District).NotEmpty();
            RuleFor(x=>x.City).NotEmpty();
            RuleFor(x=>x.Country).NotEmpty();
            
            
        }
    }
}
