using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PokerShowdown.Tests
{
    [TestClass]
    public class HandRankTest
    {
        [TestMethod]
        public void HandRank_WhenCompared_ShouldValueHigherRanktoLowerRank()
        {
            HandRank highHandRank = new HandRank
            {
                Strength = 40000
            };

            HandRank midHandRank = new HandRank
            {
                Strength = 20000
            };

            HandRank lowHandRank = new HandRank
            { 
                Strength = 10000
            };

            List<HandRank> sortedHandRanks = new List<HandRank>()
            {
                lowHandRank,
                highHandRank,
                midHandRank
            };

            List<HandRank> highToLowHandRanks = new List<HandRank>()
            {
                highHandRank,
                midHandRank,
                lowHandRank
            };

            sortedHandRanks.Sort();

            CollectionAssert.AreEqual(highToLowHandRanks, sortedHandRanks, "HandRanks are not equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_ShouldNotValueLowerRanktoHigherRank()
        {
            HandRank highHandRank = new HandRank
            {
                Strength = 40000
            };

            HandRank midHandRank = new HandRank
            {
                Strength = 20000
            };

            HandRank lowHandRank = new HandRank
            {
                Strength = 10000
            };

            List<HandRank> sortedHandRanks = new List<HandRank>()
            {
                lowHandRank,
                midHandRank,
                highHandRank
            };

            List<HandRank> lowToHighHandRanks = new List<HandRank>()
            {
                lowHandRank,
                midHandRank,
                highHandRank
            };

            sortedHandRanks.Sort();

            CollectionAssert.AreNotEqual(lowToHighHandRanks, sortedHandRanks, "HandRanks are equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_ShouldBreakTieWithHighKicker()
        {
            HandRank handRankHighKicker = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 12, 11, 10 }
            };

            HandRank handRankMidKicker = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 8, 7, 6 }
            };

            HandRank handRankLowKicker = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 5, 4, 3 }
            };

            List<HandRank> sortedHandRanks = new List<HandRank>()
            {
                handRankLowKicker,
                handRankMidKicker,
                handRankHighKicker
            };

            List<HandRank> highToLowHandRanks = new List<HandRank>()
            {
                handRankHighKicker,
                handRankMidKicker,
                handRankLowKicker
            };

            sortedHandRanks.Sort();

            CollectionAssert.AreEqual(highToLowHandRanks, sortedHandRanks, "HandRanks are not equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_ShouldBreakTieWithLastKicker()
        {
            HandRank handRankHighKicker = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 12, 11, 10 }
            };

            HandRank handRankMidKicker = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 12, 11, 9 }
            };

            HandRank handRankLowKicker = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 12, 11, 8 }
            };

            List<HandRank> sortedHandRanks = new List<HandRank>()
            {
                handRankLowKicker,
                handRankHighKicker,
                handRankMidKicker
            };

            List<HandRank> highToLowHandRanks = new List<HandRank>()
            {
                handRankHighKicker,
                handRankMidKicker,
                handRankLowKicker
            };

            sortedHandRanks.Sort();

            CollectionAssert.AreEqual(highToLowHandRanks, sortedHandRanks, "HandRanks are not equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_ShouldBreakTieWithMiddleKicker()
        {
            HandRank handRankHighKicker = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 12, 11, 10 }
            };

            HandRank handRankMidKicker = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 12, 10, 9 }
            };

            HandRank handRankLowKicker = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 12, 9, 8 }
            };

            List<HandRank> sortedHandRanks = new List<HandRank>()
            {
                handRankLowKicker,
                handRankHighKicker,
                handRankMidKicker
            };

            List<HandRank> highToLowHandRanks = new List<HandRank>()
            {
                handRankHighKicker,
                handRankMidKicker,
                handRankLowKicker
            };

            sortedHandRanks.Sort();

            CollectionAssert.AreEqual(highToLowHandRanks, sortedHandRanks, "HandRanks are not equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_ShouldNotBreakTieWithLowKicker()
        {
            HandRank handRankHighKicker = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 12, 11, 10 }
            };

            HandRank handRankMidKicker = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 9, 8, 7 }
            };

            HandRank handRankLowKicker = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 5, 4, 3 }
            };

            List<HandRank> sortedHandRanks = new List<HandRank>()
            {
                handRankLowKicker,
                handRankHighKicker,
                handRankMidKicker
            };

            List<HandRank> lowToHighHandRanks = new List<HandRank>()
            {
                handRankLowKicker,
                handRankMidKicker,
                handRankHighKicker
            };

            sortedHandRanks.Sort();

            CollectionAssert.AreNotEqual(lowToHighHandRanks, sortedHandRanks, "HandRanks are equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_HigherRankShouldBeHigherWithLowKickers()
        {
            HandRank handRankHighRank = new HandRank
            {
                Strength = 20002,
                Kickers = new List<int> { 4, 3, 2 }
            };

            HandRank handRankMidRank = new HandRank
            {
                Strength = 20001,
                Kickers = new List<int> { 9, 8, 7 }
            };

            HandRank handRankLowRank = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 12, 10, 9 }
            };

            List<HandRank> sortedHandRanks = new List<HandRank>()
            {
                handRankMidRank,
                handRankLowRank,
                handRankHighRank
            };

            List<HandRank> highToLowHandRanks = new List<HandRank>()
            {
                handRankHighRank,
                handRankMidRank,
                handRankLowRank
            };

            sortedHandRanks.Sort();

            CollectionAssert.AreEqual(highToLowHandRanks, sortedHandRanks, "HandRanks are not equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_LowerRankShouldNotBeHigherWithHigherKickers()
        {
            HandRank handRankHighRank = new HandRank
            {
                Strength = 20002,
                Kickers = new List<int> { 4, 3, 2 }
            };

            HandRank handRankMidRank = new HandRank
            {
                Strength = 20001,
                Kickers = new List<int> { 9, 8, 7 }
            };

            HandRank handRankLowRank = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 12, 10, 9 }
            };

            List<HandRank> sortedHandRanks = new List<HandRank>()
            {
                handRankMidRank,
                handRankLowRank,
                handRankHighRank
            };

            List<HandRank> highToLowHandRanks = new List<HandRank>()
            {
                handRankLowRank,
                handRankMidRank,
                handRankHighRank
            };

            sortedHandRanks.Sort();

            CollectionAssert.AreNotEqual(highToLowHandRanks, sortedHandRanks, "HandRanks are equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_EqualRanksTieWithoutKickers()
        {
            HandRank handRank1 = new HandRank
            {
                Strength = 40000
            };

            HandRank handRank2 = new HandRank
            {
                Strength = 40000
            };

            HandRank handRank3 = new HandRank
            {
                Strength = 40000
            };

            List<HandRank> sortedHandRanks = new List<HandRank>()
            {
                handRank3,
                handRank2,
                handRank1
            };

            List<HandRank> unsortedHandRanks = new List<HandRank>()
            {
                handRank3,
                handRank2,
                handRank1
            };

            sortedHandRanks.Sort();

            CollectionAssert.AreEqual(unsortedHandRanks, sortedHandRanks, "HandRanks are not equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_SortsByKickerOnlyWhenNoRank()
        {
            HandRank handRank1 = new HandRank
            {
                Kickers = new List<int> { 4, 3, 2 }
            };

            HandRank handRank2 = new HandRank
            {
                Kickers = new List<int> { 8, 7, 6 }
            };

            HandRank handRank3 = new HandRank
            {
                Kickers = new List<int> { 9, 6, 4 }
            };

            List<HandRank> sortedHandRanks = new List<HandRank>()
            {
                handRank1,
                handRank2,
                handRank3
            };

            List<HandRank> unsortedHandRanks = new List<HandRank>()
            {
                handRank3,
                handRank2,
                handRank1
            };

            sortedHandRanks.Sort();

            CollectionAssert.AreEqual(unsortedHandRanks, sortedHandRanks, "HandRanks are not equal");
        }
    }
}
