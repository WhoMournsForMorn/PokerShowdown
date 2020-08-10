using System;
using System.Collections.Generic;

namespace PokerShowdown
{
    /// <summary>
    /// <c>HandRank</c> is the representation of a <c>Hand</c> value
    /// Broken down by <c>Strength</c> meaning the value of potential <c>PokerHand</c>
    /// <c>Kickers</c> represent the <c>Strength</c> tie breakers
    /// </summary>
    public class HandRank : IComparable
    {
        public int Strength { get; set; }
        public List<int> Kickers { get; set; }

        /// <summary>
        /// <c>CompareTo</c> compares two HandRank objects by their <c>Strength</c> and <c>Kickers</c>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns><c>int</c></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            HandRank otherHandRank = obj as HandRank;

            if (Strength > otherHandRank.Strength) return -1;
            else if (Strength < otherHandRank.Strength) return 1;

            if (Kickers == null) return 0;

            for (int i = 0; i < Kickers.Count; i++)
            {
                if (Kickers[i] > otherHandRank.Kickers[i]) return -1;
                else if (Kickers[i] < otherHandRank.Kickers[i]) return 1;
            }

            return 0;
        }
    }
}
