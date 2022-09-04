using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Core.Utilities.Verification
{
    public class ActivationCode:IActivation
    {
        
        
        public string CreateCode()//random onay kodu oluşturma
        {
            
            Random random = new Random();
            var code="";
            for (int i = 0; i < 6; i++)
            {
               code += random.Next(10);
            }
            
            var result = code;
            return result;
        }

        public ActivationOptions SenderMessage(string email,string code)//mesaj gönderme
        {
            string codeKey =code ;
            string sender = "testerdenemenetflix@outlook.com";
            string senderMailPsw = "netflixtestdeneme45";

            MailMessage message = new MailMessage(sender, email,subject:"Kayıt Onayı",body:"onay kodunuz :"+codeKey);//mesaj yapısı
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);//sender mailin port ve host bilgisi
            client.Credentials = new NetworkCredential(sender, senderMailPsw);
            client.EnableSsl = true;
            try
            {
                client.Send(message);               
            }
            catch (Exception ex)
            {
                return null;
                
            }
          
            return new ActivationOptions { ActivationKey=codeKey};
        }
        
        public bool ChechkActivation(string usecode, string codeKey)
        {
            char[] usc = usecode.ToCharArray();
            char[] ck = codeKey.ToCharArray();

            for (int i = 0; i < codeKey.Length; i++)
            {
                if (ck[i]!=usc[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
