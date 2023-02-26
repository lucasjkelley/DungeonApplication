using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    public class Dinosaur : Monster
    {
        //Fields

        //Properties / PROPS
        public string SingSong { get; set; }

        //Constructors / CTORS
        public Dinosaur(string name, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description, string singSong) : base(name, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            SingSong = singSong;
        }
        public Dinosaur()
        {
            Name = "a Microraptor";
            MaxLife = 6;
            HitChance = 25;
            Block = 0;
            MaxDamage = 5;
            MinDamage = 1;
            Description = "A cute little dinosaur! You should pet it!  ...but only after you kill it.";
            SingSong = "No singing, only biting.";
        }

        //Methods
        public override string ToString()
        {
            string description = SingSong.ToString();
            return base.ToString() + $"\nDeath Song: {SingSong}\n";
        }

        public override int CalcBlock()
        {
            if (MaxLife <= 10 && MaxLife >= 5)
            {
                Console.WriteLine("Music starts playing and Barney begins singing, 'I love you, you love me, I'll re-move your skin while you scream!' +5 Damage!");
                MaxDamage += 5;
            }
            return Block;
        }

    }
}
