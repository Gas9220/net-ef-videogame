using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("softwarehouse")]
    internal class SoftwareHouse
    {
        public int SoftwareHouseId { get; set; }
        public string Name { get; set; }
        [Column("vat_number")]
        public int VatNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public List<Videogame> Videogames { get; set; }


        public SoftwareHouse(string name, int vatNumber, string city, string country)
        {
            Name = name;
            VatNumber = vatNumber;
            City = city;
            Country = country;
        }

        public override string ToString()
        {
            return $@"
Name: {Name}
Vat: {VatNumber}
City: {City}
Country: {Country}
";
        }
    }
}
