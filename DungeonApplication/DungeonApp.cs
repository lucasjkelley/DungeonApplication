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
            Player player4 = new("Little Nicky", 50, 70, 20, Race.Demon, projectile);
          

            #endregion

            Thread.Sleep(200);

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
                    player = player1;
                    break;
                case HeroList.Roland_of_Gilead:
                    Console.WriteLine("\nDon't get between him and his tower or he'll pull out his big irons, do ye ken?\n");
                    player = player2;
                    break;
                case HeroList.Tim_the_Uruk_hai:
                    Console.WriteLine("\nIt's Tim. He used to have hate in his heart and eat human flesh. Now, he's the funniest guy at the office!\n");
                    player = player3;
                    break;
                case HeroList.Little_Nicky:
                    Console.WriteLine("\nNot all demons are scary, some are even good.  This one is... special.\n");
                    player = player4;
                    break;
                default:
                    break;
            }
            Console.WriteLine("\n\nExcellent choice. Surely you won't die! Press ENTER to begin.");
            Console.ReadLine();
            Console.Clear();
            do
            {
                Console.WriteLine("You find yourself in " + GetRoom());
                Monster monster = Monster.GetMonster();
                Console.WriteLine($"\nWaiting to fight you is {monster.Name}!");

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
                                Console.WriteLine($"You killed {monster.Name}! I mean, you straight up slaughtered them. Wow. Wow!\n");
                                player.Life += 8;
                                Console.ResetColor();
                                Console.WriteLine("\n\nYou stop, only briefly, to drink the blood of your fallen enemy. You regain some health!");
                                Console.WriteLine("\nPress Enter to continue your journey.");
                                Console.ReadLine();
                                Thread.Sleep(200);
                                Console.Clear();
                                reload = true;

                                score++;
                            }
                            break;

                        case ConsoleKey.R:
                            Console.WriteLine("Run away!");
                            Console.WriteLine($"{monster.Name} has you in their grasp! With quick thinking you throw a smoke bomb to the ground. Since you can clearly be seen escaping, {monster.Name} hits you in the ass.");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;
                            break;

                        case ConsoleKey.P:
                            Console.WriteLine("Player Info: ");
                            Console.WriteLine(player);
                            break;

                        case ConsoleKey.M:
                            Console.WriteLine("Demon info: ");
                            Console.WriteLine(monster);
                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.E:
                        case ConsoleKey.Escape:
                            Console.WriteLine("Don't leave!  No one ever plays me anymore. Crying Jordan face.");
                            exit = true;
                            break;

                        default:
                            break;
                    }//end switch

                    // Check player life
                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n\t**** OH SHIT YOU DIED ****\nDeath comes for us all. However, it does seem to favor you...");
                        exit = true;
                    }
                    #endregion

                } while (!reload && !exit); // if either exit or reload is true, the inner loop
                                            //will exit.
              
            } while (!exit);//If exit is true, the outer loop will exit as well.
            #endregion
            //Show the score
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nYou defeated " + score + " demon" + (score == 1 ? "." : "s."));

            #endregion

        }//end Main()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "ye Olde English Castle. You are devastated to find absolutely no 40's of OE anywhere.\nAnger fills you as you prepare to fight, completely sober. ",
                "a cavernous room deep in the earth. The air is putrid and the whole cavern is super dank.\nAnd not in the way that internet nerds mean. Luckily, you remember that YOU are super dank, in the way internet nerds do mean, and you draw your weapon knowing victory shall come easy.",
                "a brightly colored McDonald's playplace.\nThis is literal hell for some people, blood will be shed here.",
                "an abandoned railyard. Mist layers the ground so much that it looks as if you are floating on clouds.\nStep lightly while you battle, there are things resting on the tracks that should not be jostled awake lest you want to feel the full wrath of, what the natives have named, T'homes da TuAnk Enjeen.",
                "a giant Tree house. Bigger than any tree on earth, this houses multiple rooms and levels. It's big enough that a family of bears could live here.\nThere are bones everywhere, there are piles of feces with what appear to be personal belongings speckled throughout. Hey look! My grandfather's watch! ",
                "a field of red roses around a looming tower. There is something sweet in the air, but with a bitter aftertaste reminiscent of death.\nThe tower calls to you.",
            };
            return rooms[new Random().Next(rooms.Length)];

        }//end GetRoom()
    }
}           