using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// UserInterface Experience handles all the Output for the user such as refreshing the console to update the grid, displaying the name of the player his points ...
    /// </summary>
    public static class UIExperience
    {

        public static void InitializeInterface()
        {
            GameInstrcution();
            Console.WriteLine();

            Console.Write(Constant.REQUEST_PLAYER_NAME_MESSAGE);
   
        }

        private static void GameInstrcution()
        {
            Console.WriteLine(Constant.GAME_INSTRUCTIONS);
        }
        private static void DisplayGamerInfo(string playerName)
        {
            Console.WriteLine($"Hello: {playerName}");
        }

        public static void DisplayCurrentTurnPlayer(string playerName)
        {
            Console.WriteLine($"Your turn: {playerName}");
        }
        public static void DesignGameGrid(string Headers)
        {

            Console.Write(Headers);
            Console.WriteLine();


        }

        public static void RefreshInterface()
        {
            Console.Clear();
        }

        public static void DisplayWinner(string Winner) 
        {
            RefreshInterface();
            Console.WriteLine($"The winner is: {Winner}");


        }

        //NOTE FOR ALEX IS THIS CINSDERED LOGIC ?
        public static int[] PlayerPoistionChoice()
        {
            int[] playerChoice = new int[2];
            Console.WriteLine(Constant.USER_INPUT_ROW_MESSAGE);
            string row = Console.ReadLine();

            Console.WriteLine(Constant.USER_INPUT_COL_MESSAGE);
            string col = Console.ReadLine();

            if(int.TryParse(row, out int convertedRow) && int.TryParse(col, out int convertedCol))
            {
                playerChoice[0] = convertedRow;
                playerChoice[1] = convertedCol;


            }
            else
            {
                Console.WriteLine(Constant.INPUT_NUMBER_ERROR_MESSAGE);
                PlayerPoistionChoice();
            }

            return playerChoice;
        }

        public static void DisplayCellNotEmptyMessage(string message)
        {
            Console.WriteLine(message);
        }

        internal static void EndOfGame()
        {
            Console.WriteLine(Constant.REMATCH);
            char k = Console.ReadKey().KeyChar;

            if (k == 'y') 
            {
                Program.Main(new string[1]);
            }
            Console.ReadKey();
        }
    }
}
