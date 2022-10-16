using Core.Utilities.ResultTool;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IDataResult<List<Movie>> GetAll();
        IDataResult<Movie> GetById(int movieId);
        IDataResult<List<Movie>> GetByFilter(MovieFilterDto filter);
        IResult Add(Movie movie);
        IResult Delete(int movieId);
        IResult Update(Movie movie);
    }
}
