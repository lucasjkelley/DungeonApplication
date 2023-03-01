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

        //Constructors / CTORS

        public Monster(string name, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description) : base(name, maxLife, hitChance, block)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }
        public Monster() { }

        //Methods
        public override string ToString()
        {
            return base.ToString() + $"Damage: {MinDamage} to {MaxDamage}\nDescription: {Description}";
        }

        public override int CalcDamage()
        {

            return new Random().Next(MinDamage, MaxDamage + 1);

        }

        public static Monster GetMonster()
        {
            //Create a variety of monsters
            Monster m1 = new HolyCrusader("A Holy Knight Crusader", 30, 70, 20, 8, 2, "An undead Knight Crusader!", true);
            Monster m2 = new HolyCrusader();
            Monster m3 = new Dinosaur("Barney the Dinosaur", 30, 70, 20, 8, 2, "Bloody bone-spikes stick out along his spine while his claws click-clack towards you.", "I Love you, You Love Me.");
            Monster m4 = new Dinosaur();
            Monster m5 = new KinderGods("Blippi the Destroyer", 30, 70, 20, 8, 2, "Through coughed burps of blood, you hear him say 'Hello there! Haha, oh my, just how are we going to remove that pesky head from your body? I have an idea!'", true);
            Monster m6 = new KinderGods("Thomas the Tank Engine", 30, 70, 20, 8, 2, "The train whistle bellows out 'From smokebox to bunker, you will burn until my belly is full!'", true);
            Monster m7 = new KinderGods("A BerenSTEIN Bear", 30, 70, 20, 8, 2, "I'm not like those OTHER bears, I'm going to chop you up and feed you to my family!'", true);
            Monster m8 = new KinderGods();
            Monster m9 = new ApatheticDemons("an Elder Goth Demon", 30, 70, 20, 8, 2, "Oh no! Another demon! It's .. oh wait.. um, it's just staring at me. This is weird.", 100);
            Monster m10 = new ApatheticDemons("a Nu Goth Demon", 30, 70, 20, 8, 2, "A shifty demon wearing JNCO's begins to articulate it's body towards you. Best not to make eye contact.", 100);
            Monster m11 = new ApatheticDemons();


            //add the monsters to a collection
            List<Monster> monsters = new()
            {
                m1,m1,m1,
                m2,m2,m2,m2,m2,m2,m2,
                m3,m3,m3,
                m4,m4,m4,m4,m4,m4,m4,
                m5,m5,m5,
                m6,m6,m6,
                m7,m7,m7,m7,
                m8,m8,m8,m8,m8,m8,m8,
                m9,m9,m9,
                m10,m10,m10,
                m11,m11,m11,m11,m11,m11,m11
            };

            //Pick one at random to place in our dungeon room
            return monsters[new Random().Next(monsters.Count)];

        }
    }
}