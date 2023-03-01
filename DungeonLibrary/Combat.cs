using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This is NOT a datatype class, so it will not have fields or props or ctors.
        //It will simply servie as a "warehouse" for a variety of combat-related methods.

        public static void DoAttack(Character attacker, Character defender)
        {
            //get a random number from 1-100; 
            int roll = new Random().Next(1, 101);
            Thread.Sleep(200);
            //The attacker "hits" if the roll is less than or equal to the attackers hitchance - defenders block.
            if (roll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //calc the damage
                int damageDealt = attacker.CalcDamage();
                //assign that damage to the defenders life
                defender.Life -= damageDealt;
                //output our results
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
                Console.ResetColor();
            }
            else //the attacker missed
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }
        }//end DoAttack

        public static void DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);
            //If the Monster survives, then they can attack
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}