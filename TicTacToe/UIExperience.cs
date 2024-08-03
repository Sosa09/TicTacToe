﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
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
            Console.WriteLine("Hello Please enter your name to start to play: ");
        }

        private static string _gameInstrcution()
        {
            return "The grid is composed of 3 rows and 3 columns each containing a header from 1 to 3.\n" +
                    "To place yor value in a certan plaace of the grid begin with the row and finalize with the column.\n " +
                    "FOR EXAMPLE\n" +

                    " 1 2 3" +
                    "1" +
                    "2" +
                    "3" +
                    "let's say you want to pla ce your char on the middeltop so you start with row 1 press enter then column 2 ";
        }
        private static void DisplayGamerInfo()
        {
            Console.WriteLine(_gameInstrcution();
            Console.WriteLine($"Hello: ");
        }
        public static void DesignGrid(string Headers)
        {
            
            Console.Write(Headers);
            Console.WriteLine();


        }

        public static void RefreshInterface()
        {
            DisplayGamerInfo();
            
        }

       

    }
}
