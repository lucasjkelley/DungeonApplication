using System.Linq.Expressions;

namespace DungeonLibrary
{
    //"abstract" denotes an "incomplete" class or method.
    //This tells the program that we will not create any Character objects directly.
    public abstract class Character
    {
        public static void Header(string title)
        {
            Console.Title = "======== " + title + " ========";
            Console.WriteLine("Testing Library Functionality, see entered text: " + title);
        }//end Header()

        //Fields
        private int _life;
        private int _maxLife;
        private string _name;
        private int _hitChance;
        private int _block;
        /*
         *  int life (cannot be more than maxlife)
         *  int maxlife  (in contstructor, assign maxlife before life)
         *  string name
         *  int hit chance
         *  int block
         */

        //Properties / PROPS - 1 for each field
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//end Name
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }//end HitChance
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }//end block
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value ; }
        }//end MaxLife
        public int Life
        {
            get { return _life; }
            set { _life = value > MaxLife ? MaxLife : value; }
        }//end Life


        //Constructors / CTORS - 1 fully qualified, 1 default/unqualified
        public Character(string name, int maxLife, int hitChance, int block)
        {
            Name = name;
            MaxLife = maxLife;
            Life = maxLife;
            HitChance = hitChance;
            Block = block;
        }
        public Character() { }


        //Methods
        //ToString() override
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Life: {Life} of {MaxLife}\n" +
                $"Hit Chance: {HitChance}\n" +
                $"Block: {Block}\n";
        }
        public abstract int CalcDamage();//an abstract method just says somewhere down the line, one of the child classes 
                                        //MUST implement this with some functionality
        
        public virtual int CalcHitChance()
        {
            return HitChance;
        }
        public virtual int CalcBlock()
        {
            return Block;
        }

        //CalcBlock() returns an int -> return Block;
        //CalcHitChance() returns an int -> return HitChance;
        //CalcDamage() returns an int -> return 0;
    }
}