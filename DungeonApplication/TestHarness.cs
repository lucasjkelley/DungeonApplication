﻿using System;
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
            //Build and test the functionality of our library.
            Character.Header("This is a Test\n\n");

            //Build and test a weapon
            Weapon w1 = new Weapon()
            {
                WeaponName = "Maerlyn's Staff",
                MaxDamage = 40,
                MinDamage = 5,
                BonusHitChance = 4,
                IsTwoHanded = true,
            };
            Console.WriteLine($"{w1.WeaponName}\n" +
                              $"Is Two-Handed: {w1.IsTwoHanded}\n" +
                              $"Max Damage: {w1.MaxDamage}\n" +
                              $"Min Damage: {w1.MinDamage}\n" +
                              $"Bonus Hit Chance: {w1.BonusHitChance}\n");


            //Build and test a character - include CalcBlock(), CalcHitChance(), CalcDamage()
            Character c1 = new Character()
            {
                Name = "Hero-Man",
                MaxLife = 100,
                Life = 80,
                HitChance = 95,
                Block = 25,
            };

            Console.WriteLine($"{c1}\n" +
                              $"Damage: {Character.CalcDamage()}\n" + 
                              $"Hit Chance: {Character.CalcHitChance(c1.HitChance)}\n" +
                              $"Block: {Character.CalcBlock(c1.Block)}\n");
                              
        }
    }
}