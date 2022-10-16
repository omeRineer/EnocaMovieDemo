﻿using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMovieDal : EfRepositoryBase<Movie, Context>, IMovieDal
    {
    }
}
