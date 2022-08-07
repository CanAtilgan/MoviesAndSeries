using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class FileValidator:AbstractValidator<FileRepo>
    {
        public FileValidator()
        {
            RuleFor(f=>f.EntityId).NotNull();
        }
    }
}
