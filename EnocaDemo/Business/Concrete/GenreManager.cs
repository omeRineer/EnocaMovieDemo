using Business.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenreManager : IGenreService
    {
        private readonly IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        public IResult Add(Genre genre)
        {
            _genreDal.Add(genre);
            return new SuccessResult();
        }

        public IResult Delete(int genreId)
        {
            var entity = _genreDal.Get(x => x.Id == genreId);
            _genreDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Genre>> GetAll()
        {
            var result=_genreDal.GetAll();
            return new SuccessDataResult<List<Genre>>(result);
        }

        public IDataResult<Genre> GetById(int genreId)
        {
            var result = _genreDal.Get(x => x.Id == genreId);
            return new SuccessDataResult<Genre>(result);
        }

        public IResult Update(Genre genre)
        {
            _genreDal.Update(genre);
            return new SuccessResult();
        }
    }
}
