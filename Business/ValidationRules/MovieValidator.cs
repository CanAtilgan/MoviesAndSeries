using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m=>m.CategoryId).NotEmpty();
            RuleFor(m=>m.MovieName).NotEmpty();
            RuleFor(m => m.Description).MinimumLength(20);
            RuleFor(m=>m.Direction).NotEmpty();
            RuleFor(m=>m.Photo).NotEmpty().When(m=>m.CategoryId==1);
        }
    }
}
