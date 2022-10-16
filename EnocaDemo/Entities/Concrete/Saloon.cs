using Core.Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Saloon:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<MovieSaloon> MovieSaloons { get; set; }
    }
}
