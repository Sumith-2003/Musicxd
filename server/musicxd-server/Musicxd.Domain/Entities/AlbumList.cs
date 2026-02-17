using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicxd.Domain.Entities
{
    public class AlbumList
    {
        public int AlbumId { get; set; }
        public int ListId { get; set; }
        public virtual Album Album { get; set; }
        public virtual List List { get; set; }
    }
}
