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

        public static void InitializationInterface()
        {
            GameInstrcution();
            Console.WriteLine("Hello Please enter your name to start to play: ");
        }

        private static void GameInstrcution()
        {
            Console.WriteLine("The grid is composed of 3 rows and 3 columns each containing a header from 1 to 3.\n" +
                    "To place yor value in a certan plaace of the grid begin with the row and finalize with the column.\n " +
                    "FOR EXAMPLE\n" +

                    "  1 2 3" +
                    "\n1" +
                    "\n2" +
                    "\n3" +
                    "\n" +
                    "let's say you want to pla ce your char on the middeltop so you start with row 1 press enter then column 2 ");
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
            Console.WriteLine("Enter the nr of row in which you want to insert you char");
            string row = Console.ReadLine();

            Console.WriteLine("Enter the nr of col in which you want to insert you char");
            string col = Console.ReadLine();

            if(!int.TryParse(row, out int i) || !int.TryParse(col, out int n))
            { 
                Console.WriteLine("all fields should have a must be from type integer, try again");
                PlayerPoistionChoice();
            }
            playerChoice[0] = (int.Parse(row));
            playerChoice[1] = (int.Parse(col));
            return playerChoice;

        }

        public static void DisplayCellNotEmptyMessage(string message)
        {
            Console.WriteLine(message);
        }

        internal static void EndOfGame()
        {
            Console.WriteLine("Do you want a rematch ? y or n");
            char k = Console.ReadKey().KeyChar;

            if (k == 'y') 
            {
                GameLogic.InitGameSession();
            }
            Console.ReadKey();
        }
    }
}
