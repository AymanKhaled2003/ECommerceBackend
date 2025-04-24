using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Command.Add
{
    internal class AddProductValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("اسم المنتج مطلوب")
                .MaximumLength(100).WithMessage("اسم المنتج لا يمكن أن يزيد عن 100 حرف");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("الوصف لا يمكن أن يزيد عن 500 حرف");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("السعر يجب أن يكون أكبر من 0");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("معرف التصنيف مطلوب");
        }
    }
}
