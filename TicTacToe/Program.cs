using System;
using System.Net.Http.Headers;

namespace TicTacToe
{
    /// <summary>
    /// Program class is used for handling logic between ui and database
    /// </summary>
    public class Program
    {
        static Gamer gamer;
        static int[,] grid;

        public static void Main(string[] args)
        {
            grid = _initGrid(4, 4);

            UIExperience.InitializationInterface();
            gamer = DataHandler.InitializePlayer(Console.ReadLine());
            UIExperience.DesignGrid(_refreshGameGrid(grid));

            var input = Console.ReadLine();
            var ab = input.Split(',');

            grid[int.Parse(ab[0]), int.Parse(ab[1])] = 8;
            UIExperience.DesignGrid(_refreshGameGrid(grid));



        }

        private static string _refreshGameGrid(int[,] grid)
        {
            string header = "";
            for (int i = 0; i < grid.GetLength(0); i++)
            {

                for(int j = 0; j < grid.GetLength(1); j++)
                {

     
                    int value = grid[i, j];
                    if (value == 0 || i == 0 && j == 0)
                        header += "  ";
                    else
                    {
                        header += $"{value} ";
                    }
                   
                }

                header += "\n";
            }

            return header;
        }

        private static int[,] _initGrid(int rows, int cols) 
        {
            int[,] tempGrid = new int[rows, cols];
            //TODO: change 2 the a meaningful variable like representing headers row and columns
            for (int i = 0; i < rows; i++)
            {
                if(i == 0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (j == 0)
                            continue;
                        tempGrid[i, j] = j;
                    }
                }
                else
                {
                    tempGrid[i, 0] = i;
                }




            }

            return tempGrid;
        
        }
    }
}
