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

        public int MaxDamage { get; set; }
        public string Description { get; set; } = null!;

        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value > 0 && value <= MaxDamage ? value : 1; }
        }

        //public Race PlayerRace { get; set; }

        //Constructors / CTORS
        
        public Monster(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description) : base(name, maxLife, hitChance, block)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Description = description;
            // switch (PlayerRace)
            // {
            //     case Race.Malkovich:
            //         MaxDamage += 7;
            //         break;
            // }
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + $"Damage: {MinDamage} to {MaxDamage}\nDescription: {Description}\n";
        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage +1);
        }

        public static Monster GetMonster()
        {
            //Create a variety of monsters
            Monster m1 = new("White Rabbit", hitChance: 50, block: 20, maxLife: 25, maxDamage: 8, minDamage: 2, description: "Thats no ordinary rabbit! Look at the bones!");
            Monster m2 = new("Dracula", 70, 8, 30, 8, 1, "Father of all the undead.");
            Monster m3 = new("Mikey", 50, 10, 25, 4, 1, "He is no longer a teenager, but he is still a mutant turtle.");
            Monster m4 = new(name: "Smaug", hitChance: 65, block: 20, maxLife: 20, maxDamage: 15, minDamage: 1, description: "The last great dragon.");

            //add the monsters to a collection
            List<Monster> monsters = new()
            {
                m1,m1,
                m2,m2,m2,m2,
                m3,m3,m3,
                m4,
            };

            //Pick one at random to place in our dungeon room
            return monsters[new Random().Next(monsters.Count)];

        }
    }
}
