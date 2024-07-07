using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ShopApplication.Domain.Entities;

namespace ShopApplication.Entities.validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.Email)
                .EmailAddress()
                .NotEmpty()
                .WithMessage("Email inválido ou vazio");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Email inválido ou vazio");
        }
    }
}