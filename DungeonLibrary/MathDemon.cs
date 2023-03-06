using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    public class MathDemon : Monster
    {
        public int HealthAdder { get; set; }
        public int DamageMultiplier { get; set; }

        public MathDemon(string name, int maxLife, int hitChance, int block, int maxDamage, int minDamage, string description, int healthAdder, int damageMultiplier) : base(name, maxLife, hitChance, block, maxDamage, minDamage, description)
        {
            HealthAdder = healthAdder;
            DamageMultiplier = damageMultiplier;
        }
        public MathDemon()
        {
            Name = "It looks a lot like Matt Damon";
            MaxLife = 6;
            HitChance = 25;
            Block = 0;
            MaxDamage = 5;
            MinDamage = 1;
            Description = "I serve the one and only true god, the Unit Tester!";
            HealthAdder = 10;
            DamageMultiplier = 2;
        }
        public override string ToString()
        {
            string description = HealthAdder.ToString();
            string description2 = DamageMultiplier.ToString();
            return base.ToString() + $"\nHealth Adder: {HealthAdder}\n" + $"Damage Multiplier: {DamageMultiplier}\n";
        }
        public override int CalcBlock()
        {
            return Life += HealthAdder;
        }
        public override int CalcDamage()
        {
            return HitChance *= DamageMultiplier;
        }
        public override int CalcCheck()
        {
            return MaxLife - MinDamage;
        }
    }
}
