﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MovieSaloon:IEntity
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int SaloonId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Saloon Saloon { get; set; }
    }
}
