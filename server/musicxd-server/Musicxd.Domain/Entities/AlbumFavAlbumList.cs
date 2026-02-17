using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicxd.Domain.Entities
{
    public class AlbumFavAlbumList
    {
        public int AlbumId { get; set; }
        public int FavouriteAlbumListId { get; set; }
        public virtual Album Album { get; set; }
        public virtual FavouriteAlbumList FavouriteAlbumList { get; set; }
    }
}
