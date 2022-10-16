using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        [ValidationAspect(typeof(MovieValidator))]
        public IResult Add(Movie movie)
        {
            _movieDal.Add(movie);
            return new SuccessResult();
        }

        public IResult Delete(int movieId)
        {
            var entity = _movieDal.Get(x => x.Id == movieId);
            _movieDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Movie>> GetAll()
        {
            var result = _movieDal.GetAll(null, x =>
            {
                return x.Include(y => y.Genre)
                        .Include(y => y.Director)
                        .Include(y => y.MovieSaloons).ThenInclude(x => x.Saloon);
            });
            return new SuccessDataResult<List<Movie>>(result);
        }

        public IDataResult<List<Movie>> GetByFilter(MovieFilterDto filter)
        {
            var result = _movieDal.GetAll(x => (filter.GenresId == null || filter.GenresId.Contains(x.GenreId)) &&
                                               (filter.DirectorsId == null || filter.DirectorsId.Contains(x.DirectorId)) &&
                                               x.Year >= filter.MinYear && x.Year <= filter.MaxYear,
                                               y =>
                                               {
                                                   return y.Include(s => s.Director)
                                                           .Include(s => s.Genre)
                                                           .Include(y => y.MovieSaloons).ThenInclude(x => x.Saloon);
                                               });
            return new SuccessDataResult<List<Movie>>(result);
        }

        public IDataResult<Movie> GetById(int movieId)
        {
            var result = _movieDal.Get(x => x.Id == movieId, x =>
            {
                return x.Include(y => y.Genre)
                        .Include(y => y.Director);
            });
            return new SuccessDataResult<Movie>(result);
        }

        [ValidationAspect(typeof(MovieValidator))]
        public IResult Update(Movie movie)
        {
            _movieDal.Update(movie);
            return new SuccessResult();
        }
    }
}
