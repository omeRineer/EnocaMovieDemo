using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Movie:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public int Year { get; set; }

        public virtual List<MovieSaloon> MovieSaloons { get; set; }
        public virtual Director Director { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
