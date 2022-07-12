using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{   //istekte bulunulan(request) durum sonucunda (response),yani işlemin gerçekleşip gerçekleşmemei , neden gerçekleşmediğini bildirme amaçlı
    //iş katmanındaki işlemin sonucuyla ilişkilidr 
    //encapsilation yapisi ile kuruldu
    public interface IResult
    {//sonuç gönderimi
        bool Success { get; }
        string Message { get; }
        
    }
}
