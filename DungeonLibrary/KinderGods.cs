using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class KinderGods : Monster
    {
        //Fields

        //Properties / PROPS
        public bool YouthfulSprint { get; set; }

        //Constructors / CTORS
        public KinderGods(string name, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description, bool youthfulSprint) : base(name, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            YouthfulSprint = youthfulSprint;
        }
        public KinderGods()
        {
            Name = "The most hated Teletubby";
            MaxLife = 6;
            HitChance = 25;
            Block = 0;
            MaxDamage = 5;
            MinDamage = 1;
            Description = "Which one is the most hated? All of them. Gotta kill 'em all.";
            YouthfulSprint = false;
        }

        //Methods
        public override string ToString()
        {
            string description = YouthfulSprint.ToString();
            return base.ToString() + $"\nSoul Eater: {YouthfulSprint}\n";
        }

        public override int CalcBlock()
        {
            if (YouthfulSprint == true && MaxLife <=7)
            {
                Console.WriteLine("The souls of the children I have consumed grants me enhanced speed! +5 Hit Chance!");
                HitChance += 5;
            }
            return Block;
        }

    }
}
