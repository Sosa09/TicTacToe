using System;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace TicTacToe
{
    /// <summary>
    /// Program class is used for handling logic between ui and database
    /// </summary>
    public class Program
    {
        static Gamer gamer;
        static int[,] grid;
        const int TOTAL_GRID_ROW = 4;
        const int TOTAL_GRID_COL = 4;
        const int PLAYER_CHAR = 7;
        const int AI_CHAR = ;

        public static void Main(string[] args)
        {
            _inistGameSession();
            while (true)
            {
                string row = Console.ReadLine();
                string col = Console.ReadLine();


            }


        }

        private static void  _inistGameSession()
        {
            grid = _initGrid(TOTAL_GRID_ROW, TOTAL_GRID_COL);

            UIExperience.InitializationInterface(); //Will initialize all conmponents and resourcees necessary to strat the game

            gamer = DataHandler.InitializePlayer(Console.ReadLine()); //Request user name

            UIExperience.DesignGrid(_refreshGameGrid(grid)); //initializing new game grid


        }

        private static string _refreshGameGrid(int row, int col)
        {
            if (isPlayerTurn)
                grid[row, col] = 8;
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
