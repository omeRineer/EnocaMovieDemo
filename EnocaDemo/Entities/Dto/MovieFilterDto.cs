using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class MovieFilterDto
    {
        public List<int> GenresId { get; set; }
        public List<int> DirectorsId { get; set; }
        public uint MinYear { get; set; }
        public int MaxYear { get; set; } = DateTime.Now.Year;
    }
}
