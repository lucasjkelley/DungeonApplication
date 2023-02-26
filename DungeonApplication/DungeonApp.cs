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
            //Possible expansion - Display a list of pre-created weapons and let them pick one. Or, pick one for them randomly.
            Weapon sword = new Weapon(8, 1, "Long Sword", 10, false, WeaponType.Sword);

            //Weapon w1 = new Weapon(19, 1, "Maerlyn's Rainbow", 4, true, WeaponType.Orb);

            //TODO Player Object creation
            //Potential expansion - Allow them to enter their own name.
            //Show them the possible races and let them pick one.
            Player player = new("Elroy Jenkins", 40, 70, 5, Race.Elf, sword);
            //Player player1

            #endregion

            Thread.Sleep(200);

            #region Main Game Loop
            bool exit = false;
            int innerCount = 0;
            int outerCount = 0;
            do
            {
                // Generation a random room
                Console.WriteLine(GetRoom());

                // Select a random monster to inhabit the room
                Monster monster = Monster.GetMonster();
                Console.WriteLine($"In this room is {monster.Name}!");


                #region Gameplay Menu Loop
                bool reload = false;

                do
                {
                    // Gameplay Menu
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
                            // combat
                            //Potential Expansion : weapon/race bonus attack
                            //if race == darkelf -> player.DoAttack(monster)
                            Combat.DoBattle(player, monster);
                            //check if the monster is dead
                            if (monster.Life <= 0)
                            {
                                //Combat rewards -> money, health, loot EXPANSION
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"You killed {monster.Name}!\n");
                                Console.ResetColor();
                                //flip the inner loop bool to true
                                reload = true;

                                score++;
                            }
                            break;

                        case ConsoleKey.R:
                            // Attack of opportunity
                            Console.WriteLine("Run away!");
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();//Formatting
                            reload = true;//new room, new monster
                            break;

                        case ConsoleKey.P:
                            // Player info
                            Console.WriteLine("Player Info: ");
                            Console.WriteLine(player);
                            break;

                        case ConsoleKey.M:
                            // Monster info
                            Console.WriteLine("Demon info: ");
                            Console.WriteLine(monster);
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
                    // Check player life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("\nDude, you're getting a dell! ...and you died.");
                        exit = true;
                    }

                } while (!reload && !exit); // if either exit or reload is true, the inner loop
                                            //will exit.
                #endregion

            } while (!exit);//If exit is true, the outer loop will exit as well.

            //Show the score
            Console.WriteLine("\nYou defeated " + score + " demon" + (score == 1 ? "." : "s."));

            #endregion

        }//end Main()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "Ye Olde English Castle.",
                "A cavernous room deep in the earth",
                "A brightly colored McDonald's playplace.",
                "An abandoned railyard.",
                "A giant Tree house."
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