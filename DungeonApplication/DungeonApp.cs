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
            Console.SetWindowSize(100, 40);
            Console.WriteLine(@"                                                                 ,,,           
                                                          ,,,,,,,,,,            
                                                 ,,,,,,,,,,,,,,,,,,             
                      ,                        ,,,,,,,,,,,,,,,,,,               
                    ,,,,           .,,,,,  ,,,,,,,,,,,,,,,,,,,,                 
                   ,,,,,,,,,      ,,,,,,,,,,,,,                                 
              *  ,,,,,,,,,       ,,,,,,,,,,,,                              ,,   
              ,,,,,,,,,,,,      ,,,,,,,,,,,,,,        ,                ,,,,,*   
                .,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,   ,,,              ,,,       
                ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,   ,,,,,,,,,,,,,,      
             ,,  ,,,,,,,,,,,,                  ,,,,,,,,,,,,,,,,,,,,,,,          
   ,,.     ,,,,,,,,,,,,,                            ,,,,,,,,,,,,,,,,            
   ,,,,,,,,,,,,,,,,,,                                   ,,,,,,,,,,,,            
       ,,,,,,,,,,,,                                       ,,,,,,,,,,,,          
       ,,,,,,,,,,                                           ,,,,,,,,,,,         
    ,,,,,,,,,,,                                              ,,,,,,,,,,         
     ,,,,,,,,,                                                ,,,,,,,,,       ,,
       ,,,,,,,                                                 ,,,,,,,        ,,
       ,,,,,,    +-+-+-+-+-+-+ D U N G E O N +-+-+-+-+-+-+      ,,,,,            
        ,,,,,                                                   ,,,           , 
        ,,,,,                       o f                         ,,,,          , 
       ,,,,,,                                                  ,,,,,,        ,,,
 ,,,,,,,,,,,,,   +-+-+-+-+-+-+  D E M O N S  +-+-+-+-+-+-+     ,,,,,,,,,,,,,,,, 
 ,,,,,,,,,,,,,                                                ,,,,,,,,,,,,,,    
   ,,,,,,,,,,,,                                              ,,,,,,,,,,,        
       ,,,,,,,,,,                                           ,,,,,,,,,,,         
          ,,,,,,,,,                                       ,,,,,,,,              
           ,,,,,,,,,,                                  ,,,,,,,,,,               
           ,,,,,,,,,,,,,,                           ,,,,,,,,,,,,                
        ,,,,,,,,,,,,,,,,,,,,,,                .,,,,,,,,,,,,,,,,,,               
                 ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,                    
                      ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,                        
                        ,,,,,,,,,,,,,,,,        ,,,,,,,                         
                        ,,         ,,,           *,,,,   
");
            Console.WriteLine("\n\n\t\t\tPress ENTER if you dare...");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Player & Weapon Objects

            int score = 0;

            //Possible expansion - Display a list of pre-created weapons and let them pick one. Or, pick one for them randomly.
            Weapon sword = new(6, 1, "Long Sword", 20, false, WeaponType.Sword);
            Weapon orb = new(9, 1, "Maerlyn's Rainbow", 15, true, WeaponType.Orb);
            Weapon staff = new(7, 1, "Stick of Truth", 10, true, WeaponType.Staff);
            Weapon projectile = new(12, 1, "Pineapple of BOOM", 10, false, WeaponType.Projectile);
            Weapon explosive = new(13, 1, "Cannister of Play-Don't", 9, false, WeaponType.Explosive);
            Weapon dagger = new(5, 1, "Zambezi Stinger", 22, false, WeaponType.Dagger);

            //TODO Player Object creation
            Player player = new("Elroy Jenkins", 50, 70, 15, Race.Elf, dagger);
            Player player1 = new("Zane Malkovich III", 50, 70, 10, Race.Malkovich, staff);
            Player player2 = new("Roland of Gilead, son of Steven", 50, 70, 20, Race.Human, orb);
            Player player3 = new("Tim, the Uruk-hai", 50, 70, 15, Race.Orc, explosive);
            Player player4 = new("Little Nicky", 50, 70, 10, Race.Demon, projectile);

            #endregion

            Thread.Sleep(200);

            # region Hero Selection
            Console.Write("Please select your HERO by number: \n\n");
            
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
            Console.WriteLine("\n\nExcellent choice. Surely you won't die! Press ENTER to continue to Weapon Selection.");
            Console.ReadLine();
            #endregion

            #region Weapon Selection 
            bool menuExit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Please select your Weapon!\n");
                WeaponType[] weaponChoice = Enum.GetValues<WeaponType>();
                foreach (WeaponType weapon in weaponChoice)
                {
                    string item = weapon.ToString();
                    Console.WriteLine((int)weapon + ") " + item);
                }
                int selection = int.Parse(Console.ReadLine());
                WeaponType weaponSelection = (WeaponType)selection;
                switch (weaponSelection)
                {
                    case WeaponType.Sword:
                        Console.WriteLine(sword);
                        player.EquippedWeapon = sword;
                        break;
                    case WeaponType.Dagger:
                        Console.WriteLine(dagger);
                        player.EquippedWeapon = dagger;
                        break;
                    case WeaponType.Projectile:
                        Console.WriteLine(projectile);
                        player.EquippedWeapon = projectile;
                        break;
                    case WeaponType.Staff:
                        Console.WriteLine(staff);
                        player.EquippedWeapon = staff;
                        break;
                    case WeaponType.Explosive:
                        Console.WriteLine(explosive);
                        player.EquippedWeapon = explosive;
                        break;
                    case WeaponType.Orb:
                        Console.WriteLine(orb);
                        player.EquippedWeapon = orb;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("You want this? Y/N");
                ConsoleKey confirm = Console.ReadKey(true).Key;
                if (confirm == ConsoleKey.Y)
                {
                    menuExit = true;
                }

            } while (menuExit != true); ;
            #endregion

            #region Main Game Loop
            bool exit = false;
            int innerCount = 0;
            int outerCount = 0;


            Console.Clear();
            do
            {
                Console.WriteLine("You find yourself in.... \n" + GetRoom());
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
                        "C) Change weapon\n" +
                        "P) Player Info\n" +
                        "M) Demon Info\n" +
                        "X) Exit\n");

                    Console.WriteLine($"Hero Life: {player.Life}\tDemon Life: {monster.Life}\n" +
                        $"Defeated Demons: {score}");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();
                    switch (userChoice)
                    {
                        case ConsoleKey.A:

                            Combat.DoBattle(player, monster);
                            //check if the monster is dead
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"You killed {monster.Name}! I mean, you straight up slaughtered them. Wow. Wow!\n");
                                player.Life += 8;
                                Console.ResetColor();
                                Console.WriteLine("\n\nYou stop, only briefly, to drink the blood of your fallen enemy. You regain some health!");
                                Console.WriteLine("\nPress any key to continue your journey.");
                                Console.ReadKey();
                                Thread.Sleep(200);
                                Console.Clear();
                                reload = true;

                                score++;
                            }
                            break;

                        case ConsoleKey.R:
                            Console.WriteLine($"\n{monster.Name} has you in their grasp! With quick thinking you throw a smoke bomb to the ground.\nSince you can clearly be seen escaping, {monster.Name} hits you in the ass as you flee.");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine("\nYou live to fight another day! And that day is still today. Press any key to keep going.");
                            Console.ReadKey();
                            Console.Clear();
                            reload = true;
                            break;

                        case ConsoleKey.C:
                            Console.WriteLine("Dig into your bag of goodies and grab a new weapon:\n" +
                                "A) Sword: \n" +
                                "B) Dagger: \n" +
                                "C) Projectile: \n" +
                                "D) Staff: \n" +
                                "E) Explosive: \n" +
                                "F) Orb: ");
                            ConsoleKey weaponChange = Console.ReadKey(true).Key;
                            switch (weaponChange)
                            {
                                case ConsoleKey.A:
                                    player.EquippedWeapon = sword;
                                    break;
                                case ConsoleKey.B:
                                    player.EquippedWeapon = dagger;
                                    break;
                                case ConsoleKey.C:
                                    player.EquippedWeapon = projectile;
                                    break;
                                case ConsoleKey.D:
                                    player.EquippedWeapon = staff;
                                    break;
                                case ConsoleKey.E:
                                    player.EquippedWeapon = explosive;
                                    break;
                                case ConsoleKey.F:
                                    player.EquippedWeapon = orb;
                                    break;
                                default:
                                    player.EquippedWeapon = sword;
                                    break;
                            }
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

                } while (!reload && !exit);

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
         @"
                                  |>>>
                                  |
                    |>>>      _  _|_  _         |>>>
                    |        |;| |;| |;|        |
                _  _|_  _    \\.    .  /    _  _|_  _
               |;|_|;|_|;|    \\:. ,  /    |;|_|;|_|;|
               \\..      /    ||;   . |    \\.    .  /
                \\.  ,  /     ||:  .  |     \\:  .  /
                 ||:   |_   _ ||_ . _ | _   _||:   |
                 ||:  .|||_|;|_|;|_|;|_|;|_|;||:.  |
                 ||:   ||.    .     .      . ||:  .|
                 ||: . || .     . .   .  ,   ||:   |       \,/
                 ||:   ||:  ,  _______   .   ||: , |            /`\
                 ||:   || .   /+++++++\    . ||:   |
                 ||:   ||.    |+++++++| .    ||: . |
              __ ||: . ||: ,  |+++++++|.  . _||_   |
     ____--`~    '--~~__|.    |+++++__|----~    ~`---,              ___
-~--~                   ~---__|,--~'                  ~~----_____-~'   `~----~~

ye Olde English Castle. You are devastated to find absolutely no 40's of OE anywhere. Anger fills you as you prepare to fight, completely sober.",
         @"
        _    .  ,   .           .
    *  / \_ *  / \_      _  *        *   /\'__        *
      /    \  /    \,   ((        .    _/  /  \  *'.
 .   /\/\  /\/ :' __ \_  `          _^/  ^/    `--.
    /    \/  \  _/  \-'\      *    /.' ^_   \_   .'\  *
  /\  .-   `. \/     \ /==~=-=~=-=-;.  _/ \ -. `_/   \
 /  `-.__ ^   / .-'.--\ =-=~_=-=~=^/  _ `--./ .-'  `-
/        `.  / /       `.~-^=-=~=^=.-'      '-._ `._

a cavernous room deep in the mountains. The air is putrid and the whole cavern is super dank. And not in the way that internet nerds mean. Luckily, you remember that YOU are super dank, in the way internet nerds do mean, and you draw your weapon knowing victory shall come easy.",
@"                             %%%%%%         %%%%%%                             
                            %%%   %%%       %%    %%%                           
                           %%%     %%%     %%      %%%%                         
                          %%%       %%%   %%%       %%%%                        
                         %%%        %%%% %%%        %%%%                        
                        %%%%         %%%%%%%         %%%%                       
                        %%%%         %%%%%%%         %%%%%                      
                       %%%%          %%%%%%           %%%%                      
                       %%%%           %%%%%           %%%%                      
                      %%%%%           %%%%%           %%%%%                     
                      %%%%            %%%%%           %%%%%                     
                  ///%%%%%////////////%%%%%////////////%%%%////                 
                   //%%%%%/////////////////////////////%%%%%//                  
                   //@@@@@@@  M a c D o n a l d s   @@@//@/@//                  
                   //@/@@@@/   P L A Y P L A C E    @@@//@@@/                   
                    ///////////////////////////////////////// 
                 
a brightly colored McDonald's playplace. This is literal hell for some people, blood will be shed.",
        @"
          z z z z z z z . . .
         o      _____            _______________ ___=====__T___
       .][__n_n_|DD[  ====_____  |    |.\/.|   | |   |_|     |_
      >(________|__|_[_________]_|____|_/\_|___|_|___________|_|
      _/oo OOOOO oo`  ooo   ooo   o^o       o^o   o^o     o^o
-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-
 
an abandoned railyard. Mist layers the ground so thick that it looks as if you are floating on clouds. 
Step lightly while you battle, there are things resting on the tracks that should not be jostled awake lest you want to feel the full wrath of, what the natives have named, T'homes da TuAnk Enjeen.",
  @"                                    @  (@                                       
                             %@@@@@@@@@@@@@@@@@@@@@@@                           
                         @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                        
                          @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*&@@                
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                    
             (@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  @@@ @@@@      
             #@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@       
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@        
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@& @*&    
      @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@    
       @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@    
    #@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ 
  /@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(@@@@ @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(@ 
    @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ ( .@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@, 
     @@@@@@@@@@@@@@@@@@@@@@ @@@@@@@@@@@  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@    
      @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(    
          @*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*@@@@@@@@@@@@@@@@@@    
            @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ @@@@@@@@@@@@(       ,       @@@      
            @@@@@@@@@@@@@(@@@@@   @@@@@@@@@@@@@@@@@@@@@@ @&                     
              @(@  @  @@@            @@@@@@@@@@@@@@@@                           
                                       .@@@@@@@@@                               
                                         @@@@@@@                                
                                        @@@@@@@@@*                              
                                   (@@@@@@@@@@@@@@@@@
   a giant Tree house. Bigger than any tree on earth, this houses multiple rooms and levels. It's big enough that a family of bears could live here. There are bones everywhere, there are piles of feces with what appear to be personal belongings speckled throughout. Hey look! My grandfather's watch! ",
   @"
        .n.                     
       /___\          
       [|||]         
       [___]           
       }-=-{                    
       |-'_|
       |.-'|                
~^=~^~-|_.-|~^-~^~ ~^~ -^~^~~^~~^
^   .=.| _.|__ ^~^~ -^~^~~^~~^-~^~-    
 ~ /:. \"" _|_/\  ~ ~^~ -^~^~~^~~^-~^~-      
.-/::.  |   |'|'|-._~ ~^~ -^~^~~^~~^-~^~
  `===-'-----'""""` '-. ~ ~^~ -^~^~~^~   
 ~^~ -^~^~~^~_^__^~__.-'~ ~^~ -^~^~~^~

a field of red roses around a looming tower. There is something sweet in the air, but with a bitter aftertaste reminiscent of death. The tower calls to you.",
            };
            return rooms[new Random().Next(rooms.Length)];

        }//end GetRoom()
    }
}