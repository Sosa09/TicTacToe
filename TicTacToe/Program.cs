using System;
using System.Collections.Generic;
using System.Linq;
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
        static Gamer _gamer;
        static int[,] _grid;
        const int TOTAL_GRID_ROW = 4;
        const int TOTAL_GRID_COL = 4;
        const int PLAYER_CHAR = 7;
        const int AI_CHAR = 6;
        const int BOX_EMPTY_VLAUE = 0;
        const string GAP = " ";
        static bool _isPlayerTurn = true;

        //TODO: 
        static Dictionary<string, string> _positionsList = new Dictionary<string, string>();
        static string[] _positions = { "TOP-LEFT", "TOP", "TOP-RIGHT", "MIDDLE-LEFT", "MIDDLE", "MIDDLE-RIGHT", "BOTTOM-LEFT", "BOTTOM, BOTTOM-RIGHT" };

        public static void Main(string[] args)
        {
            _initGameSession();
      
            while (true)
            {


                //UIExperience.DesignGameGrid(_refreshGameGrid(TOTAL_GRID_ROW, TOTAL_GRID_COL)); //initializing new game grid
                _defineGridPosition();
            }
        }

        private static void _defineGridPosition()
        {
            var playerPoistion = UIExperience.PlayerPoistionChoice();
            //create a method to interchange the game turn
            if (_isPlayerTurn)
            {
                _grid[playerPoistion[0], playerPoistion[1]] = PLAYER_CHAR;
                _isPlayerTurn = false;
            }
            else
            {
                _grid[playerPoistion[0], playerPoistion[1]] = AI_CHAR;
                _isPlayerTurn = true;

            }
        }

        private static void  _initGameSession()
        {
            _grid = _initGameGrid(TOTAL_GRID_ROW, TOTAL_GRID_COL);

            UIExperience.InitializationInterface(); //Will initialize all conmponents and resourcees necessary to strat the game

            _gamer = DataHandler.InitializePlayer(Console.ReadLine()); //Request user name

            UIExperience.DesignGameGrid(_refreshGameGrid(TOTAL_GRID_ROW, TOTAL_GRID_COL)); //initializing new game grid


        }

        private static string _refreshGameGrid(int row, int col)
        {

            string header = "";
            for (int i = 0; i < _grid.GetLength(0); i++)
            {

                for(int j = 0; j < _grid.GetLength(1); j++)
                {

            
                    int value = _grid[i, j];
                    if (value == BOX_EMPTY_VLAUE || i == 0 && j == 0) //i and j are the indexes while the indexes are 0 place a space to create a gapen between the row and header
                        header += GAP;
                    else
                    {
                        header += $"{value} ";
                    }
                   
                }

                header += "\n";
            }
            
            return header;
        }

        /// <summary>
        /// _initGrid is called on game initialization it defines the grid row and col
        /// </summary>
        /// <param name="rows">Takes an niterger to define the nr to rows the grid should have</param>
        /// <param name="cols">Takes an niterger to define the nr to rows the grid should have</param>
        /// <returns>
        /// returns a int array of int[4,4] and assign headers
        /// _initGrid(4,4); 
        /// THE GRID 1 2 3 header rows and colunn rows
        /// </returns>
        private static int[,] _initGameGrid(int rows, int cols) 
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
