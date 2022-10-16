using Core.Utilities.ResultTool;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISaloonService
    {
        IDataResult<List<Saloon>> GetAll();
        IDataResult<Saloon> GetById(int saloonId);
        IResult Add(Saloon saloon);
        IResult Delete(int saloonId);
        IResult Update(Saloon saloon);
    }
}
