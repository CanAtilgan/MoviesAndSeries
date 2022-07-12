using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{//t : döndürülecek tip örn : List<Product> , Product ... bunlar döndürdüğümüz t tipi
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
