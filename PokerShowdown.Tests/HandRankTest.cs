using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PokerShowdown.Tests
{
    [TestClass]
    public class HandRankTest
    {
        [TestMethod]
        public void HandRank_WhenCompared_Should_Value_High_Strength_over_Low()
        {
            HandRank highHandRank = new HandRank
            {
                Strength = 40000
            };

            HandRank lowHandRank = new HandRank
            {
                Strength = 10000
            };

            int compareValue = highHandRank.CompareTo(lowHandRank);
            int expectedValue = -1;

            Assert.AreEqual(expectedValue, compareValue, "integers are not equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_Should_Value_Low_Strength_under_High()
        {
            HandRank lowHandRank = new HandRank
            {
                Strength = 10000
            };

            HandRank highHandRank = new HandRank
            {
                Strength = 40000
            };

            int compareValue = lowHandRank.CompareTo(highHandRank);
            int expectedValue = 1;

            Assert.AreEqual(expectedValue, compareValue, "integers are not equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_Should_Value_High_Kickers_over_Low()
        {
            HandRank highHandRank = new HandRank
            {
                Kickers = new List<int> { 12, 11, 10 }
            };

            HandRank lowHandRank = new HandRank
            {
                Kickers = new List<int> { 9, 8, 7 }
            };

            int compareValue = highHandRank.CompareTo(lowHandRank);
            int expectedValue = -1;

            Assert.AreEqual(expectedValue, compareValue, "integers are not equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_Should_Value_Low_Kickers_under_High()
        {
            HandRank lowHandRank = new HandRank
            {
                Kickers = new List<int> { 9, 8, 7 }
            };

            HandRank highHandRank = new HandRank
            {
                Kickers = new List<int> { 12, 11, 10 }
            };

            int compareValue = lowHandRank.CompareTo(highHandRank);
            int expectedValue = 1;

            Assert.AreEqual(expectedValue, compareValue, "integers are not equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_Should_Value_Same_Strength_as_Equal()
        {
            HandRank firstHandRank = new HandRank
            {
                Strength = 20000
            };

            HandRank secondHandRank = new HandRank
            {
                Strength = 20000
            };

            int compareValue = firstHandRank.CompareTo(secondHandRank);
            int expectedValue = 0;

            Assert.AreEqual(expectedValue, compareValue, "integers are not equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_Should_Value_Same_Kickers_as_Equal()
        {
            HandRank firstHandRank = new HandRank
            {
                Kickers = new List<int> { 9, 8, 7 }
            };

            HandRank secondHandRank = new HandRank
            {
                Kickers = new List<int> { 9, 8, 7 }
            };

            int compareValue = firstHandRank.CompareTo(secondHandRank);
            int expectedValue = 0;

            Assert.AreEqual(expectedValue, compareValue, "integers are not equal");
        }

        [TestMethod]
        public void HandRank_WhenCompared_Should_Value_Same_StrengthKickers_as_Equal()
        {
            HandRank firstHandRank = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 9, 8, 7 }
            };

            HandRank secondHandRank = new HandRank
            {
                Strength = 20000,
                Kickers = new List<int> { 9, 8, 7 }
            };

            int compareValue = firstHandRank.CompareTo(secondHandRank);
            int expectedValue = 0;

            Assert.AreEqual(expectedValue, compareValue, "integers are not equal");
        }

        [TestMethod]
        public void HandRank_WhenSorted_Should_Value_High_to_Low()
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
        public void HandRank_WhenSorted_Should_Not_Value_Low_to_High()
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
        public void HandRank_WhenSorted_Should_Break_Tie_With_HighKicker()
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
        public void HandRank_WhenSorted_Should_Break_Tie_With_Last_Kicker()
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
        public void HandRank_WhenSorted_Should_Break_Tie_With_MiddleKicker()
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
        public void HandRank_WhenSorted_Should_Not_Break_Tie_With_LowKicker()
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
        public void HandRank_WhenSorted_High_Should_Be_Higher_With_LowKickers()
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
        public void HandRank_WhenSorted_Low_Should_Not_Be_Higher_With_HigherKickers()
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
        public void HandRank_WhenSorted_Equal_Ranks_Tie_Without_Kickers()
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
        public void HandRank_WhenSorted_Sorts_By_Kicker_Only_When_Strength()
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
