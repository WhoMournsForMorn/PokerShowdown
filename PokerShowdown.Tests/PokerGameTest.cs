using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;

namespace PokerShowdown.Tests
{
    [TestClass]
    public class PokerGameTest
    {
        [TestMethod]
        public void PokerGame_ProperlyEvaluatesAGame()
        {
            PokerGame pokerGame = new PokerGame();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                pokerGame.Evaluate();

                string expectedOutput = "Player Joe wins the game!";

                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }

    }
}
