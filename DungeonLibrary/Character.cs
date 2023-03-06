using System.Linq.Expressions;

namespace DungeonLibrary
{
   
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
        

        //Properties / PROPS 
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            set { _life = value > MaxLife ? MaxLife : value; }
        }

        //Constructors / CTORS 
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
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Life: {Life} of {MaxLife}\n" +
                $"Hit Chance: {HitChance}\n" +
                $"Block: {Block}\n";
        }
        public abstract int CalcDamage();
                                        

        public virtual int CalcHitChance()
        {
            return HitChance;
        }
        public virtual int CalcBlock()
        {
            return Block;
        }
        public virtual int CalcCheck()
        {
            return MaxLife;
        }
    }
}