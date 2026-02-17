using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicxd.Infrastructure.Data
{
    public class ExcelRow
    {
        public int Id { get; set; }
        public DateTime Year { get; set; }
        public string AlbumName { get; set; } = string.Empty;
        public string ArtistName { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
    }
}
