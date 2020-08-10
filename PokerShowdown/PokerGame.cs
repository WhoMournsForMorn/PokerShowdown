using PokerShowdown.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerShowdown
{
    public class PokerGame
    {
        public void Evaluate(int roundNumber = 1)
        {
            var playersHands = PlayerHands.GetPlayerHands1();

            if (roundNumber == 2)
            {
                playersHands = PlayerHands.GetPlayerHands2();
            } else if (roundNumber == 3)
            {
                playersHands = PlayerHands.GetPlayerHands3();
            }
            
            List<Player> players = new List<Player>();
            
            foreach(PlayerHand playerHand in playersHands)
            {
                Player player = new Player
                {
                    Name = playerHand.PlayerName,
                    Hand = new Hand { Cards = playerHand.Cards }
                };
                players.Add(player);
            }

            HandRank topHandRank = GetTopHandRank(players);

            List<Player> winners = GetWinningPlayers(topHandRank, players);

            Console.WriteLine(FormatOutput(winners));    
        }

        private HandRank GetTopHandRank(List<Player> players)
        {
            List<HandRank> handRanks = new List<HandRank>();

            players.ForEach(player => handRanks.Add(player.Hand.GetHandRank()));

            handRanks.Sort();

            return handRanks.First();
        }

        private List<Player> GetWinningPlayers(HandRank topHandRank, List<Player> players)
        {
            List<Player> winningPlayers = players.Select(player => player)
                .Where(player => topHandRank.CompareTo(player.Hand.GetHandRank()) == 0)
                .ToList();

            return winningPlayers;
        }

        private string FormatOutput(List<Player> winners)
        {
            bool multipleWinners = winners.Count > 1;
            string output = "";

            if (multipleWinners)
            {
                Player lastPlayer = winners.Last();

                foreach (Player player in winners)
                {
                    output += player.Equals(lastPlayer) ? $"{player.Name} " : output += $"{player.Name} and ";
                }
                output += "are winners!";
            }
            else
            {
                output += $"{winners[0].Name} is the winner!";
            }

            return output;
        }
    }
}
