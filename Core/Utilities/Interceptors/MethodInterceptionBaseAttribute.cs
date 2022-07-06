using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;



//ATRUBİTE KULANIM ALANI BAŞLANGIÇ KISMI PAGE -1
namespace Core.Utilities.Interceptors
{        //atribute 'u classlara veya metotlara ekleye bilirsin  //birden fazla kullanılabilir // inherit edilen yerde dde çalışsın atribute
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }//HANGİ ATRİBUTE ÖNCE ÇALIŞSIN SIRALAMASI YAPMAK İÇİN

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
