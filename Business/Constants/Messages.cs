using Core.Entities.Concrete;
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
        public static string MovieUpdate = "Film Güncellendi..";
        public static string ExistingMovie = "Bu film daha önce yüklenmiş...";
        public static string MovieImageOfCount = "Tek görsel ekleyebilirsiniz..";
        public static string RegistrationSucces = "Kullanıcı kaydı başarılı..";


        public static string SuccesCategory="Kategori başarıyla eklendi";
        public static string CategoryAvailable = "Kategori Mevcut";

        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError="Şifre Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserRegistrationSuccessful = "Kullanıcı Kayıt Başarılı";
        public static string UserAvailable = "Kullanıcı Daha Önceden Kayıt Olmuş";
        
    }
}
