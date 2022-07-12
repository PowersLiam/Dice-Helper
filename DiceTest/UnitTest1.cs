using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dice_Helper;

namespace DiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProbAccuracyTest()
        {
            //The purpose of this test is to verify the accuracy of specific results based on results found using a different program, tests each combination of stipulations
            
            Dice dice = new Dice();
            //Exact Amount of Exact Number
            Assert.AreEqual("9.439%", dice.Prob("7d12", "2", "9", false));
            //Amount or higher of Exact Number
            Assert.AreEqual("11.006%", dice.Prob("7d12", "2+", "9", false));
            //Exact Amount of Number or Higher
            Assert.AreEqual("30.727%", dice.Prob("7d12", "2", "9+", false));
            //Amount or higher of Number or Higher
            Assert.AreEqual("73.663%", dice.Prob("7d12", "2+", "9+", false));
        }
        [TestMethod]
        public void ProbLimitTest()
        {
            //The purpose of this test is to make sure that even when using the largest accepted amount of dice with the most accepted sides still produces a proper value, not NaN or infinity
            
            Dice dice = new Dice();
            Assert.IsTrue(Double.TryParse(dice.Prob("100d100", "50+", "50+", false).Substring(0, dice.Prob("100d100", "50+", "50+", false).Length-1), out double result));
        }
        [TestMethod]
        public void RollAccuracyTest()
        {
            //The purpose of this test is to ensure that all rolls are more than zero and less than or equal to the number of sides
            Dice dice = new Dice();
            string rollString = dice.Roll("100d100");
            string[] rolls = rollString.Split(", ");
            foreach(string roll in rolls)
            {
                Assert.IsTrue(Int32.Parse(roll) > 0 && Int32.Parse(roll) < 101);
            }

        }
    }
}