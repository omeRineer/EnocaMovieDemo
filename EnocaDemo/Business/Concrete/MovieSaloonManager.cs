using Business.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MovieSaloonManager : IMovieSaloonService
    {
        private readonly IMovieSaloonDal _movieSaloonDal;

        public MovieSaloonManager(IMovieSaloonDal movieSaloonDal)
        {
            _movieSaloonDal = movieSaloonDal;
        }

        public IDataResult<List<MovieSaloon>> GetAll()
        {
            var result = _movieSaloonDal.GetAll(null, x =>
            {
                return x.Include(y => y.Movie)
                        .Include(y => y.Saloon);
            });
            return new SuccessDataResult<List<MovieSaloon>>(result);
        }
    }
}
