using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonApplication
{
    internal class TestHarness
    {
        static void Main(string[] args)
        {
            //Build and test a weapon
            Console.WriteLine("\n\n+++++++++++++ WEAPON ++++++++++++++++\n");
            Weapon w1 = new(40, 5, "Maerlyn's Rainbow", 4, true, WeaponType.Orb);
            Console.WriteLine(w1);

            //Build and test a character - include CalcBlock(), CalcHitChance(), CalcDamage()
            Console.WriteLine("\n++++++++++++++ HERO +++++++++++++++\n");
            Player c1 = new("Hero-Man",100,50,25,Race.Human,w1);

            Console.WriteLine(c1);

            Console.WriteLine($"Damage: {c1.CalcDamage()}\n" +
                              $"Hit Chance: {c1.CalcHitChance()}\n" +
                              $"Block: {c1.CalcBlock()}\n");

            //Call to a random Monster
            Console.WriteLine("\n\n ++++++++++++++ MONSTER +++++++++++++++\n\n");
            Console.WriteLine(Monster.GetMonster());
            Monster monster = Monster.GetMonster();

            Console.WriteLine("\n\n ++++++++++++++++++++ COMBAT ++++++++++++++++++++\n\n");
            Combat.DoBattle(c1, monster);

        }
    }
}
