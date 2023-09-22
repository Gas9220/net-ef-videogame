using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("videogame")]
    internal class Videogame
    {
        public int VideogameId { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }

        public int SoftwareHouseId { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }
    }
}
