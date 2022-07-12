using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{//Aspect : Metonun başında ,sonunda veya ortasında hata verdiğinde çalışacak yapı.
    public class ValidationAspect : MethodInterception //aspect yapımız bu classta yer alır 
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//atributlara tipi type ile atanır .
        {
            //defensive coding : savunma odaklı kodlama
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//gönderilen type , ıvalidatorden implemente edilebilen doğrulama sınıfımı bak , değilse hatayı fırlat
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir.");
            }

            _validatorType = validatorType;//gönderilen type doğrulanabilir yapılı olduğunda onu eşitleme yapar bu kısımda
        }
        protected override void OnBefore(IInvocation invocation)//doğrulama işleminin hangi aşamada çalışmaya başlayacığını bildirilir
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//çalışma anında instance oluşturma için activator.creatinstance() kullanılır , bu satır newleme yapıyor , productvalidtor!ı yakalar
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//gelen type'ın(productvalidator),base sınıfındanın generic parametresini(abstracvalidator<product>) 0 ıncı tipini yakaladı , product tipini yakalar
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//ilgili metotun argumanlarını gez , ordaki tip  entitype türünde ise onları validate et foreachle 
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
