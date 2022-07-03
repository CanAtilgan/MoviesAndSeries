using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{//temel void yapilari için
    public class Result : IResult
    {                                               //çalıştıracağı diğer contu işaretledik, tekrarlamayı önlemek için
        public Result(bool success , string message):this(success)
        {//readonli'ler constrocter içinde set edilebilir .(sadece get olan özellik durumu olanlarda)
            Message = message;
        }
        public Result(bool success)
        {//readonli'ler constrocter içinde set edilebilir .(sadece get olan özellik durumu )
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}