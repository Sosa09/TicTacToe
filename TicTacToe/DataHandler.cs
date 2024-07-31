using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public static class DataHandler
    {
        public static List<Gamer> gamers = new List<Gamer>();

        /// <summary>
        /// Will initialize player instance with his name
        /// points set to 0
        /// totalwins to 0 
        /// totallosses to 0
        /// </summary>
        /// <param name="playerName">represents the player name</param>
        public static void InitializePlayer(string playerName)
        {

        }

        /// <summary>
        /// Will return the Actual Gamer's name
        /// </summary>
        /// <param name="gamer">Takes instance of Model Gamer</param>
        /// <returns></returns>
        public static string GetPlayerName(Gamer gamer)
        {
            return gamer.Name;
        }


        /// <summary>
        /// Will return the Actual Gamer's name
        /// </summary>
        /// <param name="gamer">Takes instance of Model Gamer</param>
        /// <returns>Points</returns>
        public static int GetPlayerPoints(Gamer gamer)
        {
            return gamer.Points;
        }
        /// <summary>
        /// Will return the Actual Gamer's total Wins
        /// </summary>
        /// <param name="gamer">Takes instance of Model Gamer</param>
        /// <returns>TotalWins</returns>
        public static int GetPlayerWins(Gamer gamer)
        {
            return gamer.TotalWins;
        }
        /// <summary>
        /// Will return the Actual Gamer's total Losses
        /// </summary>
        /// <param name="gamer">Takes instance of Model Gamer</param>
        /// <returns></returns>
        public static int GetPlayerLosses(Gamer gamer)
        {
            return gamer.TotalLosses;
        }



        public static void AddPoints(Gamer gamer, int points)
        {
            gamer.Points = points;
        }
        public static void PlayerWon(Gamer gamer)
        {
            gamer.TotalWins++;
        }
        public static void PlayerLost(Gamer gamer)
        {
            gamer.TotalLosses++;
        }

    }
}
