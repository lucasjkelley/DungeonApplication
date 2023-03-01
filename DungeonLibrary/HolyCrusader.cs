using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class HolyCrusader : Monster
    {
        //Fields

        //Properties / PROPS
        public bool PalmSunday { get; set; }

        //Constructors / CTORS
        public HolyCrusader(string name, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description, bool palmSunday) : base(name, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            PalmSunday = palmSunday;
        }
        public HolyCrusader()
        {
            Name = "a Lowly Squire";
            MaxLife = 6;
            HitChance = 25;
            Block = 20;
            MaxDamage = 5;
            MinDamage = 1;
            Description = "It's just a squire!  He is recognized by the Knights but he will never achieve the rank of Knight!";
            PalmSunday = false;
        }
        //Methods
        public override string ToString()
        {
            string description = PalmSunday.ToString();
            return base.ToString() + $"\nIs Blessed?: {PalmSunday}\n";
        }

        public override int CalcBlock()
        {
            if (PalmSunday == true && MaxLife <= 10 && MaxLife >= 5)
            {
                Console.WriteLine("The Gods have granted the Holy Crusader a resurrection bonus! +15 health!");
                MaxLife += 15;
            }
            return Block;
        }
    }
}