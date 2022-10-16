using Core.Utilities.ResultTool;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDirectorService
    {
        IDataResult<List<Director>> GetAll();
        IDataResult<Director> GetById(int directorId);
        IResult Add(Director director);
        IResult Delete(int directorId);
        IResult Update(Director director);
    }
}
