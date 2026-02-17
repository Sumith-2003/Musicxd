using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicxd.Domain.Entities
{
    public class AlbumArtist
    {
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }
        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
