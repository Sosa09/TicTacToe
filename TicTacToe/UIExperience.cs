﻿using System;
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
        public static void DesignGameGrid(int[,] grid)
        {
            string headers = RefreshInterface(grid);
            Console.Write(headers);
            Console.WriteLine();


        }

        public static string RefreshInterface(int[,] grid)
        {
            Console.Clear();
            string cell = "";

            for (int i = 0; i < grid.GetLength(0); i++)
            {

                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int value = grid[i, j];

                    if (value == Constant.BOX_EMPTY_VALUE || i == 0 && j == 0) //i and j are the indexes while the indexes are 0 place a space to create a gapen between the row and header
                        cell += Constant.GAP;
                    else
                    {
                        cell += $"{value} ";
                    }

                }

                cell += "\n";
            }



            return cell;
        }

        public static void DisplayWinner(string Winner) 
        {
            Console.Clear();
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
