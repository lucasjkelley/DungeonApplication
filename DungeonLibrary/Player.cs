using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //Fields - none

        //Properties / PROPS
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //Constructors / CTORS
        public Player(string name, int maxLife, int hitChance, int block, Race playerRace, Weapon equippedWeapon) : base(name, maxLife, hitChance, block) 
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;

            #region Potential Expansion - Racial Bonuses
            switch (PlayerRace)
            {
                case Race.Human:
                    HitChance += 5;
                    break;
                case Race.Elf:
                    Block += 3;
                    break;
                case Race.Malkovich:
                    HitChance += 7;
                    break;
                case Race.Orc:
                    Block += 4;
                    break;
                case Race.Demon:
                    MaxLife += 5;
                    break;
            }
            #endregion
        }

        //Methods
        public override string ToString()
        {
            string description = PlayerRace.ToString();
            switch (PlayerRace)
            {
                case Race.Orc:
                    Console.WriteLine("Player Race: Orc - They're ugly but effective!");
                    break;
                case Race.Human:
                    Console.WriteLine("Player Race: Human - Too many flaws to list, but they aight.");
                    break;
                case Race.Elf:
                    Console.WriteLine("Player Race: Elf - Super old, but super cool. The ears are pretty dope too.");
                    break;
                case Race.Malkovich:
                    Console.WriteLine("Player Race: Malkovich - You've likely heard about John, of the race Malkovich, but there are many many more like him.");
                    break;
                case Race.Demon:
                    Console.WriteLine("Player Race: Demon - Some Demons are mean, some are nice. It's all about perspective.");
                    break;
                default:
                    break;
            }
            return base.ToString() + $"\nWeapon: {EquippedWeapon}\n";
        }


        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }
    }
}
