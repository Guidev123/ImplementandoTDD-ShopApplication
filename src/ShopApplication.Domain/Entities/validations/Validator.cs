using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using ShopApplication.Domain.Interfaces;
using ShopApplication.Domain.Notifications;

namespace ShopApplication.Domain.Entities.validations
{
    public abstract class Validator
    {
        private readonly INotificator _notificator;

        protected Validator(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Notify(erro.ErrorMessage);
            }
        }
        protected void Notify(string errorMessage)
        {
            _notificator.AddNotification(new Notification(errorMessage));
        }

        protected bool EntityIsValid<TValidation, TEntity>(TValidation validation, TEntity entity) where TValidation : AbstractValidator<TEntity>
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);
            return false;
        }
    }
}