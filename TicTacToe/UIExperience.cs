using System;
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
        static int[,] grid = new int[4, 4];
        public static void InitializationInterface()
        {
            Console.WriteLine("Hello Please enter your name to start to play: ");
        }

        public static void DisplayGamerInfo()
        {
            Console.WriteLine($"Name: ");
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
