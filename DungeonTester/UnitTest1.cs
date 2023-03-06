using DungeonLibrary;

namespace DungeonTester
{
    public class UnitTest1
    {
        [Fact]

        public void TestCalcDamage()
        {
            //Arrange
            Monster m55 = new HolyCrusader("A Holy Knight Crusader", 30, 70, 20, 8, 2, "An undead Knight Crusader!", true);

            int expectedMinDamage = 2;
            int expectedMaxDamage = 8;

            int actualMinDamage = 2;
            int actualMaxDamage = 8;

            //Act

            int expectedCalcDamage = new Random().Next(expectedMinDamage, expectedMaxDamage + 1);
            int actualCalcDamage = m55.CalcDamage();


            //Assert
            Assert.True(expectedCalcDamage >= 2 && expectedCalcDamage <= 9 && actualCalcDamage >= 2 && actualCalcDamage <= 9);
            
        }
        [Fact]
        public void TestCalcHitChance()
        {
            //Arrange
            Weapon w55 = new(5, 1, "Zambezi Stinger", 22, false, WeaponType.Dagger);
            Player p55 = new("Elroy Jenkins", 50, 70, 15, Race.Elf, w55);

            int expectedHitChance = 0;
            int actualHitChance = 0;

            //Act
            expectedHitChance = p55.HitChance + w55.BonusHitChance;
            actualHitChance = p55.CalcHitChance();


            //Assert
            Assert.Equal(expectedHitChance, actualHitChance);                      

        }
        [Fact]
        public void TestHealthAdd()
        {
            //Arrange
            Monster m56 = new MathDemon("Jerry", 20, 20, 5, 25, 1, "It's Jerry", 10, 2);

            int expectedHealthAdd = 0;
            int actualHealthAdd = 0;

            //Act
            expectedHealthAdd = 20 + 10;
            actualHealthAdd = m56.CalcBlock();

            //Assert
            Assert.Equal(expectedHealthAdd, actualHealthAdd);
        }
        [Fact]
        public void TestDamageMultiply()
        {
            //Arrange
            Monster m57 = new MathDemon("Tom", 20, 20, 5, 25, 1, "It's Tom", 10, 2);

            int expectedDamMulti = 0;
            int actualDamMulti = 0;

            //Act
            expectedDamMulti = 20 * 2;
            actualDamMulti = m57.CalcDamage();

            //Assert
            Assert.Equal(expectedDamMulti, actualDamMulti);
        }
        [Fact]
        public void TestCalcCheck()
        {
            //Arrange
            Monster m58 = new MathDemon("Other Tom", 20, 20, 5, 25, 1, "It's not that Tom", 10, 2);

            int expectedOutput = 0;
            int actualOutput = 0;

            //Act
            expectedOutput = 20 - 1;
            actualOutput = m58.CalcCheck();

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}