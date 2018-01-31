using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class DiceTests
    {
        [TestMethod()]
        public void RollTest()
        {
            var res = Dice.Roll(1);
            Assert.IsTrue(res > 0 && res < 7);
        }

        [TestMethod]
        public void RollMultipleDice()
        {
            var res = Dice.Roll(2);
            Assert.IsTrue(res > 1 && res < 13);
            var res2 = Dice.Roll(10);
            Assert.IsTrue(res2 > 9 && res2 < 61);
        }

        [TestMethod]
        public void RollMultipleTimes()
        {
            int[] res = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                res[i] = Dice.Roll(1);
            }
            Assert.IsTrue(res.Min() > 0);
            Assert.IsTrue(res.Max() < 7);
        }
        [TestMethod]
        public void RollTwoDIceMultipleTimes()
        {
            int[] res = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                res[i] = Dice.Roll(2);
            }
            Assert.IsTrue(res.Min() > 1);
            Assert.IsTrue(res.Max() < 13);
        }
    }
}