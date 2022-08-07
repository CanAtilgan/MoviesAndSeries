using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class FileManager : IFileService
    {
        IFileRepoDal _fileRepoDal;
        

        public FileManager(IFileRepoDal fileRequestDal)
        {
            _fileRepoDal = fileRequestDal;
        }
        [ValidationAspect(typeof(FileValidator))]
        public IResult Add(FileRequestDto fileUploadRequest)
        {
            var indexofData = fileUploadRequest.Base64.IndexOf(";base64,", StringComparison.OrdinalIgnoreCase) + 8; //datanın başlangıç indexini tespit etme

            var dataS = fileUploadRequest.Base64.Substring(indexofData);//data için kaçıncı indexten sonra alınacak
                                                                        //var demo = Convert.FromBase64String(dataS);

            string dosyaYolu = $@"C:\Api\Assets\{fileUploadRequest.Collection}\{fileUploadRequest.EntityId}\";//klasör adı ve nesnenin ıdsi
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

            var fR = new FileRepo()
            {
                FileName = fileUploadRequest.FileName,
                Collection = fileUploadRequest.Collection,
                EntityId = fileUploadRequest.EntityId,
                FileType= fileUploadRequest.DataType,
                AddedUserId = fileUploadRequest.AddedUserId,
                State = true,
            };
            _fileRepoDal.Add(fR);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(FileRequestDto fileUploadRequest)
        {
            var fileRepo =  _fileRepoDal.Get(f=>f.EntityId == fileUploadRequest.EntityId &&  f.Collection == fileUploadRequest.Collection);
            string dosyaYolu = $@"C:\Api\Assets\{fileUploadRequest.Collection}\{fileRepo.EntityId}";
            bool exists = Directory.Exists(dosyaYolu);
           
            if (exists==true)
            {
               
                        fileRepo.State = false;
                        _fileRepoDal.Update(fileRepo);
                        //_fileRepoDal.Delete(fileRepo);
                        return new SuccessResult("başarıyla silindi");
                 
            }
            return new ErrorResult();
            
        }

        public IDataResult<FileRequestDto> Get(int id)
        {
            var fileRepo = _fileRepoDal.Get(f=>f.Id==id);
            var file = $@"C:\Api\Assets\{fileRepo.Collection.Trim()}\{fileRepo.EntityId}\{fileRepo.FileName}{fileRepo.FileType.Trim()}_";
            
            bool exixts = File.Exists(file);
            if (exixts == true)
            {

                var statesonuc = (bool)fileRepo.State? 1 : 0;
                if (statesonuc==1)
                {
                    var base64 = File.ReadAllBytes(file);
                    var base6 = Convert.ToBase64String(base64);
                    //var result = ($@"{file}{id.EntityId}", Convert.ToBase64String(basee));
                    return new SuccessDataResult<FileRequestDto>(new FileRequestDto
                    {
                        AddedUserId = fileRepo.AddedUserId,
                        Collection = fileRepo.Collection,
                        DataType = fileRepo.FileType,
                        EntityId = fileRepo.EntityId,
                        FileName = fileRepo.FileName,
                        Id = fileRepo.Id,
                        Base64 = base6
                    });
                }
                return new ErrorDataResult<FileRequestDto>("SEÇİLEN DOSYA BULUNAMADI");
            }
            return new ErrorDataResult<FileRequestDto>("Hatalı");
        }

        //public IDataResult<List<FileRequestDto>> GetAll()
        //{
            
        //    var filePath = $@"C:\Api\Assets";
           
        //    var exixt = Directory.Exists(filePath);
        //    if (exixt == true)
        //    {
        //        string[] allfile = Directory.GetFiles(filePath,"*.*",SearchOption.AllDirectories);
        //        foreach (var f in allfile)
        //        {
        //            Console.WriteLine(f);
        //            return new SuccessDataResult<List<FileRequestDto>>(new FileRequestDto().FileName) ;
        //        }
                
        //    }
        //    return null;
        //}
    }
}
