using DungeonLibrary;

namespace DungeonApplication
{
    internal class DungeonApp
    {
        static void Main(string[] args)
        {
            #region Title/Introduction
            Console.Title = "+-+-+-+-+-+-+ D U N G E O N  of  D E M O N S +-+-+-+-+-+-+";
            Console.WriteLine("Your journey begins...\n");
            #endregion

            #region Player Creation
            //TODO Variable to keep score
            int score = 0;
            //TODO Weapon creation
            Weapon w1 = new Weapon()
            {
                WeaponName = "Maerlyn's Staff",
                Type = WeaponType.Staff,
                MaxDamage = 40,
                MinDamage = 5,
                BonusHitChance = 4,
                IsTwoHanded = true,
            };
            //TODO Player Object creation
            Player c1 = new("Hero-Man", 100, 50, 25, Race.Human, w1);

            #endregion

            #region Main Game Loop
            bool exit = false;
            int innerCount = 0;
            int outerCount = 0;
            do
            {
                //Console.WriteLine("Outer " + ++outerCount);
                //TODO Generation a random room
                Console.WriteLine(GetRoom());
                //TODO Select a random monster to inhabit the room
                Console.WriteLine("Here's a demon!");
                #region Gameplay Menu Loop
                bool reload = false;
                
                do
                {
                    //Console.WriteLine("Inner " + ++innerCount);
                    //TODO Gameplay Menu
                    #region Menu
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player Info\n" +
                        "M) Demon Info\n" +
                        "X) Exit\n");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //TODO combat
                            Console.WriteLine("ATTACK!");
                            break;

                        case ConsoleKey.R:
                            //TODO Attack of opportunity
                            Console.WriteLine("Run away!");
                            reload = true;
                            break;

                        case ConsoleKey.P:
                            //TODO Player info
                            Console.WriteLine("Player Info: ");
                            break;
                        
                        case ConsoleKey.M:
                            //TODO Monster info
                            Console.WriteLine("Demon info: ");
                            break;
                        
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                        case ConsoleKey.Escape:
                            Console.WriteLine("No one likes a quitter...");
                            exit = true;
                            //reload = true; or see while below
                            break;

                        default:
                            break;
                    }//end switch

                    #endregion
                    //TODO Check player life

                } while (!reload && !exit); // if either exit or reload is true, the inner loop
                                            //will exit.
                #endregion

            } while (!exit);//If exit is true, the outer loop will exit as well.

            //Show the score
            Console.WriteLine("You defeated " + score + " demon" + (score == 1 ? "." : "s."));

            #endregion

        }//end Main()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "1","2","3","4","5"
            };

            Random rand = new Random();

            int index = rand.Next(rooms.Length);

            string room = rooms[index];

            return room;

            //possible refactor
            return rooms[new Random().Next(rooms.Length)];

        }//end GetRoom()

    }
}