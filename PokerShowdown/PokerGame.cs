using PokerShowdown.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerShowdown
{
    public class PokerGame
    {
        public void Evaluate()
        {
            var playersHands = PlayerHands.GetPlayerHands();
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
            string output = multipleWinners ? "Players" : "Player";

            foreach (Player player in winners)
            {
                output += $" {player.Name}";
            }

            output += multipleWinners ? " win" : " wins";
            output += " the game!";

            return output;
        }
    }
}
