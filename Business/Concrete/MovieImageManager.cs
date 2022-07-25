using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class MovieImageManager : IMovieImageService
    {


        public IResult Add(FileRequestDto fileUploadRequest)
        {
            var indexofData = fileUploadRequest.Base64.IndexOf(";base64,", StringComparison.OrdinalIgnoreCase) + 8; //datanın başlangıç indexini tespit etme

            var dataS = fileUploadRequest.Base64.Substring(indexofData);//data için kaçıncı indexten sonra alınacak
                                                                        //var demo = Convert.FromBase64String(dataS);

            string dosyaYolu = $@"C:\Api\Assets\{fileUploadRequest.Collection}\{fileUploadRequest.EntityId}\";
            bool exists = Directory.Exists(dosyaYolu);
            var fileType = fileUploadRequest.FileName.Substring(fileUploadRequest.FileName.LastIndexOf(".") + 1);
            //var fileName = GuidHelper.CreateGuid();
            if (exists == true)
            {
                File.WriteAllBytes($@"{dosyaYolu}{fileUploadRequest.FileName}.{fileType}_", Convert.FromBase64String(dataS));
            }

            else
            {
                DirectoryInfo di = Directory.CreateDirectory(dosyaYolu);
                File.WriteAllBytes($@"{dosyaYolu}{fileUploadRequest.FileName}.{fileType}_", Convert.FromBase64String(dataS));
            }
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(FileRequestDto fileUploadRequest)
        {
            string dosyaYolu = $@"C:\Api\Assets\{fileUploadRequest.Collection}\{fileUploadRequest.EntityId}\";
            bool exists = Directory.Exists(dosyaYolu);
            
            if (exists==true)
            {
                string[] bull = Directory.GetFiles(dosyaYolu);//ilgili klasör içinde 
                string filtre = fileUploadRequest.FileName;
                
                foreach (string file in bull)
                {
                    bool result = file.Contains(filtre);
                    if(result==true)
                    {
                        File.Delete(file);
                        return new SuccessResult("başarıyla silindi");
                    }
                }
            }
            return new ErrorResult();
            
        }

        
    }
}
