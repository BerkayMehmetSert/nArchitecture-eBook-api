using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using static Project.Application.Features.Categories.Constants.CategoryMessages;
namespace Project.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Request.Name)
                .NotEmpty().WithMessage(CategoryNameIsRequired);

            RuleFor(x => x.Request.Name)
                .MinimumLength(2).WithMessage(CategoryNameIsMinimumCharacters);

        }
    }
}
