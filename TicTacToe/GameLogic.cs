using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public static class GameLogic
    {
        public static bool IsPlayerTurn = true;
        /// <summary>
      
        /// </summary>
        /// <param name="playerName">represents the player name</param>
        public static void InitializePlayer(string playerName, int playerChar )
        {
            
        }


        public static int[] AITurn()
        {
            int[] ai_poistions = new int[2];
            Random random = new Random();
            ai_poistions[0] = random.Next(1, 4);
            ai_poistions[1] = random.Next(1, 4);
            return ai_poistions;

        }

        public static int[] PlayerTurn()
        {
            throw new NotImplementedException();
        }
    }
}
