using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using net_ef_videogame;

namespace adonet_db_videogame
{
    public static class VideogameManager
    {
        public static void CreateSH()
        {
            using (VideogameContext db = new VideogameContext())
            {
                SoftwareHouse sh1 = new SoftwareHouse { Name = "Rockstar Games", VatNumber = 111111, City = "New York", Country = "America" };
                SoftwareHouse sh2 = new SoftwareHouse { Name = "Ubisoft", VatNumber = 22222, City = "Montreal", Country = "Canada" };
                db.Add(sh1);
                db.Add(sh2);
                db.SaveChanges();
            }
        }

        public static void InsertGame()
        {
            using (VideogameContext db = new VideogameContext())
            {
                Videogame newVideogame = CreateVideogame();
                db.Add(newVideogame);
                db.SaveChanges();
            }

        }
        public static void SearchById()
        {

        }

        public static void SearchByName()
        {

        }

        public static void DeleteGame()
        {

        }
        private static Videogame CreateVideogame()
        {
            string name = Helpers.checkValidString("Videogame name: ", "Cannot be empty");
            string overview = Helpers.checkValidString("Videogame overview: ", "Cannot be empty");
            DateTime date = Helpers.checkValidDate("Videogame release date: ", "Date in wrong format");
            int swh = Helpers.checkValidInt("Videogame Software house: ", "Insert a valid number");

            Videogame newVideogame = new Videogame(name, overview, date, swh);

            return newVideogame;
        }
    }
}
