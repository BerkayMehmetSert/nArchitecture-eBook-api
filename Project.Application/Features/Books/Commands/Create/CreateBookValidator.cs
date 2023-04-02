﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using static Project.Application.Features.Books.Constants.BookMessages;

namespace Project.Application.Features.Books.Commands.Create
{
    public class UpdateBookValidator : AbstractValidator<CreateBookCommand>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.Request.Name)
                .NotEmpty()
                .WithMessage(BookNameIsRequired);

            RuleFor(x => x.Request.Author)
                .NotEmpty()
                .WithMessage(BookAuthorIsRequired);

            RuleFor(x => x.Request.Publisher)
                .NotEmpty()
                .WithMessage(BookPublisherIsRequired);

            RuleFor(x => x.Request.CategoryId)
                .NotEmpty()
                .WithMessage(BookCategoryIdIsRequired);
        }
    }
}
