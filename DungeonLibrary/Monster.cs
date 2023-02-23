using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //Fields
        private int _minDamage;

        //Properties / PROPS
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value > MaxDamage ? MaxDamage : value; }
        }
        public int MaxDamage { get; set; }
       
        public string Description { get; set; } = null!;

        public Race PlayerRace { get; set; }

        //Constructors / CTORS
        public Monster()
        {

        }
        public Monster(string name, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base (name, maxLife, hitChance, block)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Description = description;
            switch (PlayerRace)
            {
                case Race.Malkovich:
                    MaxDamage += 7;
                    break;
            }
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + $"\nDescription: {Description}\n";
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(MinDamage, MaxDamage + 1);
            return damage;
        }

    }
}
