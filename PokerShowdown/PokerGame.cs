using PokerShowdown.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerShowdown
{
    /// <summary>
    /// Class <c>PokerGame</c> evaluates a set of cards associated to players and declares a winner(s)
    /// </summary>
    public class PokerGame
    {
        /// <summary>
        /// method <c>Evaluate</c> accepts an int to determine what hands to play and declares a winner
        /// </summary>
        /// <param name="roundNumber"></param>
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

        /// <summary>
        /// <c>GetTopHandRank</c> determines the highest value hand from all players passed 
        /// </summary>
        /// <param name="players"></param>
        /// <returns><c>HandRank</c></returns>
        private HandRank GetTopHandRank(List<Player> players)
        {
            List<HandRank> handRanks = new List<HandRank>();

            players.ForEach(player => handRanks.Add(player.Hand.GetHandRank()));

            handRanks.Sort();

            return handRanks.First();
        }

        /// <summary>
        /// <c>GetWinningPlayers</c> determines which players match the top <c>HandRank</c>
        /// </summary>
        /// <param name="topHandRank"></param>
        /// <param name="players"></param>
        /// <returns><c>List<Player></c></returns>
        private List<Player> GetWinningPlayers(HandRank topHandRank, List<Player> players)
        {
            List<Player> winningPlayers = players.Select(player => player)
                .Where(player => topHandRank.CompareTo(player.Hand.GetHandRank()) == 0)
                .ToList();

            return winningPlayers;
        }

        /// <summary>
        /// <c>FormatOutput</c> Formats the string output into the appropriate message
        /// </summary>
        /// <param name="winners"></param>
        /// <returns><c>string</c></returns>
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
