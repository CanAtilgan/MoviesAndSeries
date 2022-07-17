using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Core.Utilities.FilePath
{
    public class FilePath
    {
        //private static (string newPath, string Path2) newPath(IFormFile file)
        //{
        //    FileInfo ff = new FileInfo(file.FileName); // dosyaya referans oluşturma 
        //    string fileExtension = ff.Extension;
        //    var newFileName = Guid.NewGuid().ToString("N") + fileExtension;
        //    string path2 = @"C:\imagesAndVideo";
        //    string result = Environment.CurrentDirectory + path2 + newFileName;
        //    return (result, $"\\Images\\{newFileName}");
        //}
        
        public static void Dco()
        {
            string path2 = $@"C:\Users\HasanCan\images";
            if (!File.Exists(path2))
            {
                using (FileStream fs = File.Create($@"C:\Users\HasanCan\images"))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path2);

                }
            }
            Console.WriteLine(File.Exists(path2)? "DOSYA VAR " : "DOSYA YOK");
            
        }
        



    }
}
