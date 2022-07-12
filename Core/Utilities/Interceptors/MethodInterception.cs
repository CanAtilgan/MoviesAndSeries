using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{ //interception : araya girmek anlamına gelir,başında -sonunda-hata verdiğinde çalışmak 
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation) //İNVOCTAİN , ÇALIŞTIRMAK İSTEDİĞİMİZ METOT OLMUŞ OLUYOR - add-update... hangisi gelirse business tarafından
        {
            var isSuccess = true;
            OnBefore(invocation);//METONUN BAŞINDA ÇALIŞTIR
            try //TRY - CATCH HATA YAKALAMA BLOGUDUR
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e); // HATA ALDIĞIN ZAMAN ÇALIŞTIR 
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);// METOT BAŞARILI OLDUĞUNDA ÇALIŞSIN
                }
            }
            OnAfter(invocation); // METOT SONRASINDA ÇALIŞSIN
        }
    }
}
