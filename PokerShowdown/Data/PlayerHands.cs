using System;
using System.Collections.Generic;
using System.Text;

namespace PokerShowdown.Data
{
    public class PlayerHand
    {
        public string PlayerName { get; set; }
        public List<Card> Cards { get; set; }
    }
    public static class PlayerHands
    {
        static readonly Card aceSpades = new Card
        {
            Suit = Suit.Spades,
            Rank = Rank.Ace
        };
        static readonly Card aceClubs = new Card
        {
            Suit = Suit.Clubs,
            Rank = Rank.Ace
        };
        static readonly Card queenDiamonds = new Card
        {
            Suit = Suit.Diamonds,
            Rank = Rank.Queen
        };

        static readonly Card sevenHearts = new Card
        {
            Suit = Suit.Hearts,
            Rank = Rank.Seven
        };

        static readonly Card tenHearts = new Card
        {
            Suit = Suit.Hearts,
            Rank = Rank.Ten
        };

        static readonly Card aceHearts = new Card
        {
            Suit = Suit.Hearts,
            Rank = Rank.Ace
        };

        static readonly Card aceDiamonds = new Card
        {
            Suit = Suit.Diamonds,
            Rank = Rank.Ace
        };

        static readonly Card kingDiamonds = new Card
        {
            Suit = Suit.Diamonds,
            Rank = Rank.King
        };

        static readonly Card queenHearts = new Card
        {
            Suit = Suit.Hearts,
            Rank = Rank.Queen
        };

        static readonly Card twoHearts = new Card
        {
            Suit = Suit.Hearts,
            Rank = Rank.Two
        };

        static readonly Card threeCLubs = new Card
        {
            Suit = Suit.Clubs,
            Rank = Rank.Three
        };

        static readonly Card fiveClubs = new Card
        {
            Suit = Suit.Clubs,
            Rank = Rank.Five
        };

        static readonly Card twoSpades = new Card
        {
            Suit = Suit.Spades,
            Rank = Rank.Two
        };

        static readonly Card sevenDiamonds = new Card
        {
            Suit = Suit.Diamonds,
            Rank = Rank.Seven
        };

        static readonly Card nineClubs = new Card
        {
            Suit = Suit.Clubs,
            Rank = Rank.Nine
        };
        public static IEnumerable<PlayerHand> GetPlayerHands()
        {
            yield return new PlayerHand
            {
                PlayerName = "Joe",
                Cards = new List<Card> { aceSpades, kingDiamonds, sevenHearts, aceDiamonds, aceClubs }
            };
            yield return new PlayerHand
            {
                PlayerName = "Jen",
                Cards = new List<Card> { queenDiamonds, tenHearts, queenHearts, aceHearts, twoHearts }

            };
            yield return new PlayerHand
            {
                PlayerName = "Bob",
                Cards = new List<Card> { threeCLubs, fiveClubs, twoSpades, sevenDiamonds, nineClubs }

            };
        }
    }
}
