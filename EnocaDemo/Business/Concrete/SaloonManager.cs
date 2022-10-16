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
    public class SaloonManager : ISaloonService
    {
        private readonly ISaloonDal _saloonDal;

        public SaloonManager(ISaloonDal saloonDal)
        {
            _saloonDal = saloonDal;
        }

        public IResult Add(Saloon saloon)
        {
            _saloonDal.Add(saloon);
            return new SuccessResult();
        }

        public IResult Delete(int saloonId)
        {
            var entity=_saloonDal.Get(x=>x.Id==saloonId);
            _saloonDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Saloon>> GetAll()
        {
            var result = _saloonDal.GetAll();
            return new SuccessDataResult<List<Saloon>>(result);
        }

        public IDataResult<Saloon> GetById(int saloonId)
        {
            var result = _saloonDal.Get(x => x.Id == saloonId);
            return new SuccessDataResult<Saloon>(result);
        }

        public IResult Update(Saloon saloon)
        {
            _saloonDal.Update(saloon);
            return new SuccessResult();
        }
    }
}
