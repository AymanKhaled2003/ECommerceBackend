using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Auth.Command.Register
{
    
        public class RegisterValidator : AbstractValidator<RegisterCommand>
        {
            public RegisterValidator()
            {
                RuleFor(x => x.UserName)
                    .NotEmpty().WithMessage("UserName is required.")
                    .MinimumLength(3).WithMessage("UserName must be at least 3 characters long.");

                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email is required.")
                    .EmailAddress().WithMessage("Invalid email format.");

                RuleFor(x => x.Password)
                    .NotEmpty().WithMessage("Password is required.")
                    .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            }
        }
    
}
