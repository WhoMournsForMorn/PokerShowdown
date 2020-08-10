using System.Collections.Generic;
using System.Linq;

namespace PokerShowdown
{
    /// <summary>
    /// <c>PokerHand</c> an enum of potential poker hands and associated values enlarged for normalization
    /// </summary>
    public enum PokerHand
    {
        HighCard = 10000,
        OnePair = 20000,
        ThreeOfAKind = 30000,
        Flush = 40000
    }

    /// <summary>
    /// <c>Hand</c> represents a poker hand
    /// </summary>
    public class Hand
    {
        public IEnumerable<Card> Cards { get; set; }

        /// <summary>
        /// <c>GetHandRank</c> iterates through a list of <c>Card</c> and determines the HandRank of that grouping
        /// </summary>
        /// <returns><c>HandRank</c></returns>
        public HandRank GetHandRank()
        {
            HandRank handRank = new HandRank
            {
                Strength = (int)PokerHand.HighCard,
                Kickers = Cards.Select(card => (int)card.Rank).OrderByDescending(rank => rank).ToList()
            };

            var flush = Cards.GroupBy(card => card.Suit)
                   .Where(suitGroup => suitGroup.Count() == 5).ToList();
            var cardGroup = Cards.GroupBy(card => card.Rank).ToList();
            var threeOfAKind = -1;
            var onePair = -1;

            foreach (var group in cardGroup)
            {
                var count = group.Count();
                if (count == 3) threeOfAKind = (int)group.Key;
                if (count == 2) onePair = (int)group.Key;
            }

            if (flush.Count() > 0)
            {
                handRank.Strength = (int)PokerHand.Flush;
                handRank.Kickers = Cards.Select(card => (int)card.Rank).OrderByDescending(rank => rank).ToList();
            }
            else if (threeOfAKind > 0)
            {
                handRank.Strength = (int)PokerHand.ThreeOfAKind + threeOfAKind;
                handRank.Kickers = Cards.Where(card => (int)card.Rank != threeOfAKind)
                    .Select(card => (int)card.Rank).OrderByDescending(rank => rank).ToList();
            }
            else if (onePair > 0)
            {
                handRank.Strength = (int)PokerHand.OnePair + onePair;
                handRank.Kickers = Cards.Where(card => (int)card.Rank != onePair)
                    .Select(card => (int)card.Rank).OrderByDescending(rank => rank).ToList();
            }

            return handRank;
        }
    }
}
