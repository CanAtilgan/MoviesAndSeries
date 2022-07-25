using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Core.Entities;

namespace Core.Utilities.FilePath
{
    public class FileRequestPath<T> where T : class, IFileDirection, new()
    {
        
        
        public static void Dco(T entity)
        {
            
            string path2 = $@"C:\Users\HasanCan\cinesbox\image";//klasör yolu 
            if (!Directory.Exists(path2))//klasör kontorlü - var mı yok mu
            {
                Directory.CreateDirectory(path2);//klasör oluşturma
                
                Console.WriteLine("dosya oluşturuldu");
            }
            

            string pt = Path.GetTempFileName();//Diskte benzersiz olarak adlandırılmış, sıfır baytlık geçici bir dosya oluşturur ve bu dosyanın tam yolunu döndürür.
            //string path3 = ;
            var fi = new FileInfo(path2); //Dosyaların oluşturulması, kopyalanması, silinmesi, taşınması ve açılması için özellikler ve örnek yöntemleri sağlar
                                          //ve nesnelerin oluşturulmasına FileStream yardımcı olur. Bu sınıf devralınamaz.
            string ext = fi.Extension;//dosyanın tam adıyla başlayan ve son noktayı (.) içeren uzantıyı döndürür

            var newFileName = Guid.NewGuid().ToString("D")+ext +"__";//kaydedilecek dosyanın adını oluşturma
            FileStream fs = File.Create($@"{path2}\images\{newFileName}\{entity}.txt");//dosya oluşturma
            string result = Environment.CurrentDirectory + newFileName;
            Console.WriteLine(ext.Length);


        }
        public void Add(T entity)
        {
            //Dco();
            
            Console.WriteLine("result" + entity);
        }



    }
}
