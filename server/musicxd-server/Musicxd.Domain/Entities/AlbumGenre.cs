using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicxd.Domain.Entities
{
    public class AlbumGenre
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public virtual Album Album { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
