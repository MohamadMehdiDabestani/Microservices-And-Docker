using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Order.Command.CheckoutOrder
{
    public class CheckoutOrderValidator : AbstractValidator<CheckoutOrderCommand>
    {
        [Obsolete]
        public CheckoutOrderValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("user name is required")
                .NotNull()
                .MaximumLength(50).WithMessage("user namemust not exceed 50 characters.");

            RuleFor(e => e.EmailAddress)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("Email is not valid")
                .NotEmpty().WithMessage("Email is required .");


        }
    }
}
