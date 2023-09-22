using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using net_ef_videogame;
using Microsoft.EntityFrameworkCore;

namespace adonet_db_videogame
{
    public static class VideogameManager
    {
        public static void CreateSH()
        {
            using (VideogameContext db = new VideogameContext())
            {
                SoftwareHouse newSoftwareHouse = CreateSoftwareHouse();
                db.Add(newSoftwareHouse);
                db.SaveChanges();

                Console.Write("New SH: ");
                Console.WriteLine(newSoftwareHouse.ToString());
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
            int videogameIdToFind = Helpers.checkValidInt("Videogame to find (by id): ", "Insert a valid number");

            using (VideogameContext db = new VideogameContext())
            {
                Videogame? videogame = db.Videogames.Where(videogame => videogame.VideogameId == videogameIdToFind).FirstOrDefault();

                if (videogame != null)
                {
                    Console.WriteLine(videogame.ToString());
                }
                else
                {
                    Console.WriteLine("No videogames was found");
                }
            }
        }

        public static void SearchByName()
        {
            string videoGameName = Helpers.checkValidString("Videogame to find (by name): ", "Can't be empty");

            using (VideogameContext db = new VideogameContext())
            {
                Videogame? videogame = db.Videogames.Where(videogame => videogame.Name.StartsWith(videoGameName)).FirstOrDefault();

                if (videogame != null)
                {
                    Console.WriteLine(videogame.ToString());
                }
                else
                {
                    Console.WriteLine("No videogames was found");
                }
            }
        }

        public static void DeleteGame()
        {
            int idVideogameToDelete = Helpers.checkValidInt("Videogame to delete (by id): ", "Insert a valid number");

            using (VideogameContext db = new VideogameContext())
            {
                Videogame? videogame = db.Videogames.Where(videogame => videogame.VideogameId == idVideogameToDelete).FirstOrDefault();

                if (videogame != null)
                {
                    Console.WriteLine(videogame.ToString() + "Successfully deleted");
                    db.Remove(videogame);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("No videogames was found");
                }
            }
        }

        public static void GetSoftwareHouseGames()
        {
            int idSoftwareHouseToFind = Helpers.checkValidInt("Search games for (by software house id): ", "Can't be empty");

            using (VideogameContext db = new VideogameContext())
            {
                List<Videogame> videogames = db.Videogames.Where(videogame => videogame.SoftwareHouseId == idSoftwareHouseToFind).OrderBy(videogame => videogame.Name).ToList();

                if (videogames.Count > 0)
                {
                    foreach (var game in videogames)
                    {
                        Console.WriteLine(game.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No software house was found");
                }
            }
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
        private static SoftwareHouse CreateSoftwareHouse()
        {
            string name = Helpers.checkValidString("SoftwareHouse name: ", "Cannot be empty");
            int vatNumber = Helpers.checkValidInt("Software house VAT: ", "Insert a valid number");
            string city = Helpers.checkValidString("Software house city: ", "Cannot be empty");
            string country = Helpers.checkValidString("Software house country: ", "Cannot be empty");

            SoftwareHouse newSoftwareHouse = new SoftwareHouse(name, vatNumber, city, country);

            return newSoftwareHouse;
        }
    }
}
