using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PokerShowdown.Tests
{
    [TestClass]
    public class HandTest
    {
        Card aceSpades = new Card
        {
            Suit = Suit.Spades,
            Rank = Rank.Ace
        };

        Card aceClubs = new Card
        {
            Suit = Suit.Clubs,
            Rank = Rank.Ace
        };

        Card queenDiamonds = new Card
        {
            Suit = Suit.Diamonds,
            Rank = Rank.Queen
        };

        Card sevenHearts = new Card
        {
            Suit = Suit.Hearts,
            Rank = Rank.Seven
        };

        Card tenHearts = new Card
        {
            Suit = Suit.Hearts,
            Rank = Rank.Ten
        };

        Card aceHearts = new Card
        {
            Suit = Suit.Hearts,
            Rank = Rank.Ace
        };

        Card kingDiamonds = new Card
        {
            Suit = Suit.Diamonds,
            Rank = Rank.King
        };

        Card queenHearts = new Card
        {
            Suit = Suit.Hearts,
            Rank = Rank.Queen
        };

        Card twoHearts = new Card
        {
            Suit = Suit.Hearts,
            Rank = Rank.Two
        };

        [TestMethod]
        public void Hand_Calculates_OnePair_Strength()
        {   

            Hand hand = new Hand
            {
                Cards = new List<Card> { aceSpades, aceClubs, queenDiamonds, sevenHearts, tenHearts }
            };

            int assumedStrength = 20012;
            HandRank handRank = hand.GetHandRank();
            int calculatedStrength = handRank.Strength;

            Assert.AreEqual(assumedStrength, calculatedStrength, "Hand strengths do not match");
        }

        [TestMethod]
        public void Hand_Calculates_ThreeOfAKind_Strength()
        {

            Hand hand = new Hand
            {
                Cards = new List<Card> { aceSpades, aceClubs, queenDiamonds, kingDiamonds, aceHearts }
            };

            int assumedStrength = 30012;
            HandRank handRank = hand.GetHandRank();
            int calculatedStrength = handRank.Strength;

            Assert.AreEqual(assumedStrength, calculatedStrength, "Hand strengths do not match");
        }

        [TestMethod]
        public void Hand_Calculates_HighCard_Strength()
        {

            Hand hand = new Hand
            {
                Cards = new List<Card> { twoHearts, aceClubs, queenDiamonds, kingDiamonds, tenHearts }
            };

            int assumedStrength = 10000;
            HandRank handRank = hand.GetHandRank();
            int calculatedStrength = handRank.Strength;

            Assert.AreEqual(assumedStrength, calculatedStrength, "Hand strengths do not match");
        }

        [TestMethod]
        public void Hand_Calculates_Flush_Strength()
        {

            Hand hand = new Hand
            {
                Cards = new List<Card> { twoHearts, sevenHearts, queenHearts, aceHearts, tenHearts }
            };

            int assumedStrength = 40000;
            HandRank handRank = hand.GetHandRank();
            int calculatedStrength = handRank.Strength;

            Assert.AreEqual(assumedStrength, calculatedStrength, "Hand strengths do not match");
        }

        [TestMethod]
        public void Hand_Kickers_Are_Ordered()
        {
            Hand hand = new Hand
            {
                Cards = new List<Card> { aceSpades, aceClubs, queenDiamonds, sevenHearts, tenHearts }
            };

            List<int> assumedKickerOrder = new List<int> { 10, 8, 5 };
            HandRank handRank = hand.GetHandRank();
            List<int> calculatedKickerOrder = handRank.Kickers;

            CollectionAssert.AreEqual(assumedKickerOrder, calculatedKickerOrder, "Hand Kickers do not match");
        }

        [TestMethod]
        public void Hand_OnePair_Has_Three_Kickers()
        {

            Hand hand = new Hand
            {
                Cards = new List<Card> { aceSpades, aceClubs, queenDiamonds, sevenHearts, tenHearts }
            };

            int assumedKickersCount = 3;
            HandRank handRank = hand.GetHandRank();
            int calculatedKickersCount = handRank.Kickers.Count;

            Assert.AreEqual(assumedKickersCount, calculatedKickersCount, "Hand Kickers do not match");
        }

        [TestMethod]
        public void Hand_ThreeOfAKind_Has_Two_Kickers()
        {

            Hand hand = new Hand
            {
                Cards = new List<Card> { aceSpades, aceClubs, queenDiamonds, kingDiamonds, aceHearts }
            };

            int assumedKickersCount = 2;
            HandRank handRank = hand.GetHandRank();
            int calculatedKickersCount = handRank.Kickers.Count;

            Assert.AreEqual(assumedKickersCount, calculatedKickersCount, "Hand Kickers do not match");
        }

        [TestMethod]
        public void Hand_HighCard_Has_Five_Kickers()
        {

            Hand hand = new Hand
            {
                Cards = new List<Card> { twoHearts, aceClubs, queenDiamonds, kingDiamonds, tenHearts }
            };

            int assumedKickersCount = 5;
            HandRank handRank = hand.GetHandRank();
            int calculatedKickersCount = handRank.Kickers.Count;

            Assert.AreEqual(assumedKickersCount, calculatedKickersCount, "Hand Kickers do not match");
        }

        [TestMethod]
        public void Hand_Flush_Has_Five_Kickers()
        {

            Hand hand = new Hand
            {
                Cards = new List<Card> { twoHearts, sevenHearts, queenHearts, aceHearts, tenHearts }
            };

            int assumedKickersCount = 5;
            HandRank handRank = hand.GetHandRank();
            int calculatedKickersCount = handRank.Kickers.Count;

            Assert.AreEqual(assumedKickersCount, calculatedKickersCount, "Hand Kickers do not match");
        }
    }
}
