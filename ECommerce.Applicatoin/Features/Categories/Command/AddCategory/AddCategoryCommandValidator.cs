using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Categories.Command.AddCategory
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("اسم القسم مطلوب")
                .MaximumLength(100).WithMessage("اسم القسم يجب ألا يتجاوز 100 حرف");
        }
    }
}
