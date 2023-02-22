using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    //Make it public! 
    public class Weapon
    {
        //Fields
        private int _minDamage;
        private int _maxDamage;
        private string _weaponName;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        private WeaponType _type;

        /*
         * int for min damage (business rule that it cannot be less than 0 or > max)
         * int for max damage (cannot be less than 0) - assign this one first in CTOR
         * string for the name (of the weapon)
         * int for bonusHitChance
         * bool for isTwoHanded
         */

        //Properties / PROPS - 1 for each field
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value > MaxDamage ? MaxDamage : value; }
        }//end MinDamage
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value <= 0 ? 0 : value; }
        }//end MaxDamage
        public string WeaponName
        {
            get { return _weaponName; }
            set { _weaponName = value; }
        }//end WeaponName
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }//end BonusHitChance
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }//end IsTwoHanded
        public WeaponType Type
        {
            get { return _type; }
            set { _type = value; }
        }


        //Constructors / CTORS
        //1 fully qualified and 1 unqualified ctor if you want Object Initialization Syntax
        public Weapon(int maxDamage, int minDamage, string weaponName, int bonusHitChance, bool isTwoHanded, WeaponType type)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            WeaponName = weaponName;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            Type = type;
        }
        public Weapon() { }

        //Methods
        //Nicely formatted ToString() override
        public override string ToString()
        {
            return $"{WeaponName}\n" +
                $"Type: {Type}\n" +
                $"Max Damage: {MaxDamage}\n" +
                $"Min Damage: {MinDamage}\n" +
                $"Bonus Hit Chance: {BonusHitChance}\n" +
                $"Is Two Handed: {IsTwoHanded}\n";
        }
    }
}
