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
        //no fields or props needed, just methods to call 

        public static void DoAttack(Character attacker, Character defender)
        {
            
            int roll = new Random().Next(1, 101);
            Thread.Sleep(200);            
            if (roll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {                
                int damageDealt = attacker.CalcDamage();                
                defender.Life -= damageDealt;                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
                Console.ResetColor();
            }
            else 
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }

        }//end DoAttack

        public static void DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}

