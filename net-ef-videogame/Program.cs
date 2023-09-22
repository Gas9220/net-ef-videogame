using adonet_db_videogame;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($@"
What would you like to do?
- 1 Insert a new game
- 2 Search game by id
- 3 Search game by name
- 4 Delete a videogame
- 5 Create new software house
- 6 Close the program
");

            int userChoice = Helpers.checkValidInt("Choose an option from 1 to 6: ", "Insert a valid number...");

            switch (userChoice)
            {
                case 1:
                    VideogameManager.InsertGame();
                    break;
                case 2:
                    VideogameManager.SearchById();
                    break;
                case 3:
                    VideogameManager.SearchByName();
                    break;
                case 4:
                    VideogameManager.DeleteGame();
                    break;
                case 5:
                    VideogameManager.CreateSH();
                    break;
                case 6:
                    System.Environment.Exit(1);
                    break;
                default:
                    break;
            }
        }
    }
}