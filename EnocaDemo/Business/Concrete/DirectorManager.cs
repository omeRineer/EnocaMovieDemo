using Business.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DirectorManager : IDirectorService
    {
        private readonly IDirectorDal _directorDal;

        public DirectorManager(IDirectorDal directorDal)
        {
            _directorDal = directorDal;
        }

        public IResult Add(Director director)
        {
            _directorDal.Add(director);
            return new SuccessResult();
        }

        public IResult Delete(int directorId)
        {
            var entity = _directorDal.Get(x => x.Id == directorId);
            _directorDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Director>> GetAll()
        {
            var result = _directorDal.GetAll();
            return new SuccessDataResult<List<Director>>(result);
        }

        public IDataResult<Director> GetById(int directorId)
        {
            var result = _directorDal.Get(x => x.Id == directorId);
            return new SuccessDataResult<Director>(result);
        }

        public IResult Update(Director director)
        {
            _directorDal.Update(director);
            return new SuccessResult();
        }
    }
}
