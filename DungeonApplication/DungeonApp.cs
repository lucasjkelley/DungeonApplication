using DungeonLibrary;
using System.ComponentModel;

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
            
            int score = 0;

            //Possible expansion - Display a list of pre-created weapons and let them pick one. Or, pick one for them randomly.
            Weapon sword = new(8, 1, "Long Sword", 10, false, WeaponType.Sword);
            Weapon orb = new(8, 1, "Maerlyn's Rainbow", 10, true, WeaponType.Orb);
            Weapon staff = new(8, 1, "Stick of Truth", 10, true, WeaponType.Staff);
            Weapon projectile = new(8, 1, "Pineapple of BOOM", 10, false, WeaponType.Projectile);
            Weapon explosive = new(8, 1, "Cannister of Play-Don't", 10, false, WeaponType.Explosive);
            Weapon dagger = new(8, 1, "Zambezi Stinger", 10, false, WeaponType.Dagger);


            //TODO Player Object creation
            Player player = new("Elroy Jenkins", 40, 70, 5, Race.Elf, dagger);
            Player player1 = new("Zane Malkovich III", 40, 70, 5, Race.Malkovich, staff);
            Player player2 = new("Roland of Gilead, son of Steven", 50, 70, 20, Race.Human, orb);
            Player player3 = new("Tim, the Uruk-hai", 50, 70, 20, Race.Orc, explosive);
            Player player4 = new("Little Nicky", 50, 70, 20, Race.Demon, explosive);
            List<Player> players = new List<Player>()
            {
                player, player1, player2, player3, player4
            };

            #endregion

            #region Main Game Loop
            bool exit = false;
            int innerCount = 0;
            int outerCount = 0;

            Console.Write("Please select your HERO by number: \n");
            HeroList[] heroes = Enum.GetValues<HeroList>();
            foreach (HeroList hero in heroes)
            {
                string item = hero.ToString().Replace('_', ' ');
                Console.WriteLine((int)hero + ") " + item);
            }

            int input = int.Parse(Console.ReadLine());
            HeroList userHero = (HeroList)input;
            switch (userHero)
            {
                case HeroList.Elroy_Jenkins:
                    Console.WriteLine("\nNo no, that's his older brother. Yeah, he gets it all the time, it's okay. No worries.\n");
                    break;
                case HeroList.Zane_Malkovich_III:
                    Console.WriteLine("\nNot your ordinary Malkovich. Hmmm, do those even exist?\n");
                    break;
                case HeroList.Roland_of_Gilead:
                    Console.WriteLine("\nDon't get between him and his tower or he'll pull out his big irons, do ye ken?\n");
                    break;
                case HeroList.Tim_the_Uruk_hai:
                    Console.WriteLine("\nIt's Tim. He used to have hate in his heart and eat human flesh. Now, he's the funniest guy at the office!\n");
                    break;
                case HeroList.Little_Nicky:
                    Console.WriteLine("\nNot all demons are scary, some are even good.  This one is... special.\n");
                    break;
                default:
                    break;
            }

            do
            {
                Console.WriteLine("You find yourself in " + GetRoom());
                Monster monster = Monster.GetMonster();
                Console.WriteLine($"Waiting to fight you is {monster.Name}!");

                #region Gameplay Menu Loop
                bool reload = false;
                
                do
                {
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

                    // Check player life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("\nDeath comes for us all. But it does seem to favor you...");
                        exit = true;
                    }
                    #endregion

                } while (!reload && !exit); // if either exit or reload is true, the inner loop
                                            //will exit.
              

            } while (!exit);//If exit is true, the outer loop will exit as well.
            #endregion
            //Show the score
            Console.WriteLine("You defeated " + score + " demon" + (score == 1 ? "." : "s."));

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
                "A giant Tree house.",
                "A field of red roses around a looming tower",
                "A giant Tree house."
            };
            return rooms[new Random().Next(rooms.Length)];

        }//end GetRoom()
    }
}           