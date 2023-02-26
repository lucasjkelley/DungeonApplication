using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class ApatheticDemons : Monster
    {
        //Fields

        //Properties / PROPS
        public int ApathyLevel { get; set; }

        //Constructors / CTORS
        public ApatheticDemons(string name, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description, int apathyLevel) : base(name, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            ApathyLevel = apathyLevel;
        }
        public ApatheticDemons()
        {
            Name = "a Teen Goth Demon";
            MaxLife = 6;
            HitChance = 25;
            Block = 0;
            MaxDamage = 5;
            MinDamage = 1;
            Description = "I really, truly, from the bottom of my black heart... do not care.";
            ApathyLevel = 50;
        }

        //Methods

        public override string ToString()
        {
            string description = ApathyLevel.ToString();
            return base.ToString() + $"\nApathy Level: {ApathyLevel}\n";
        }
        public override int CalcBlock()
        {
            if (ApathyLevel > 100)
            {
                Console.WriteLine("This is so meh. Just kill me so I can get back to my nihilism and EBM. ugh.  Block - 5");
                Block -= 5;
            }
            return Block;
        }
    }
}
