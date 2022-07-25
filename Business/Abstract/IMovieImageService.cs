using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMovieImageService
    {
        IResult Add(FileRequestDto movieImage);
        IResult Delete(FileRequestDto fileUploadRequest);
        //IResult Update(FileRequestDto movieImage);
        //IDataResult<List<FileRequestDto>> GetAll();
        //IDataResult<FileRequestDto> GetById(int id);
    }
}
