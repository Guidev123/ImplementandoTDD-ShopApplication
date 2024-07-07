using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ShopApplication.Domain.Entities;

namespace ShopApplication.Entities.validations
{
    public class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
            RuleFor(o => o.Customer)
                .NotEmpty()
                .WithMessage("Cliente inválido ou vazio");


            RuleFor(o => o.Number)
                .NotEmpty()
                .WithMessage("Numero inválido ou vazio");
        }
    }
}