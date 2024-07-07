using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ShopApplication.Domain.Entities;

namespace ShopApplication.Entities.validations
{
    public class OrderItemValidation : AbstractValidator<OrderItem>
    {
        public OrderItemValidation()
        {
            RuleFor(o => o.Item)
                .NotEmpty()
                .WithMessage("Item inválido ou vazio");

            RuleFor(o => o.Quantity)
                .NotEmpty()
                .WithMessage("A quantidade deve ser maior que zero");
        }
    }
}