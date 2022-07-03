using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{//static yapi ile , sürekli onu newleme durumundan kurtarıp tek instance'ı olmuş olur 
    public static class Messages
    {
        public static string UsersListed = "Kullanıcılar listelendi..";
        public static string UserUpdate = "Kullanıcı bilgileri güncellendi..";
        public static string UserUpdateError = "Kullanıcı bilgileri güncellenemedi!!!.";
    }
}
