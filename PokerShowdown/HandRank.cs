using System;
using System.Collections.Generic;
using System.Text;

namespace PokerShowdown
{
    public class HandRank : IComparable
    {
        public int Strength { get; set; }
        public List<int> Kickers { get; set; }

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
