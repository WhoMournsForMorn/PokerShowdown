using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace PokerShowdown.Tests
{
    [TestClass]
    public class PokerGameTest
    {
        [TestMethod]
        public void PokerGame_Correctly_Evaluates_Game1()
        {
            PokerGame pokerGame = new PokerGame();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                pokerGame.Evaluate();

                string expectedOutput = "Joe is the winner!";

                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }

        [TestMethod]
        public void PokerGame_Correctly_Evaluates_Game2()
        {
            PokerGame pokerGame = new PokerGame();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                pokerGame.Evaluate(2);

                string expectedOutput = "Jen is the winner!";

                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }

        [TestMethod]
        public void PokerGame_Correctly_Evaluates_Game3()
        {
            PokerGame pokerGame = new PokerGame();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                pokerGame.Evaluate(3);

                string expectedOutput = "Joe and Jen are winners!";

                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }
    }
}
