using Core.Utilities.ResultTool;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IGenreService
    {
        IDataResult<List<Genre>> GetAll();
        IDataResult<Genre> GetById(int genreId);
        IResult Add(Genre genre);
        IResult Delete(int genreId);
        IResult Update(Genre genre);

    }
}
