using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        //Ortak bir interface bulup onu validator olarak veriyoruz bu sayede refarans özelliğinden orası değişken yapıda olur 
        //object ise , en genel veri tipi olduğu için oraya istelen nesne yollanılabilir işlem için
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
