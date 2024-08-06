using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
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
        const int PLAYER_CHAR = 5;
        const int AI_CHAR = 7;
        const int AI_INDEX = 0;
        const int PLAYER_INDEX = 1;
        const int BOX_EMPTY_VALUE = 0;
        const string GAP = " ";


        public static void Main(string[] args)
        {
            _initGameSession();
            while(true)
            {
                _defineGridPosition();
                _switchPlayerTurn();
            }

        }

        private static void _initGameSession()
        {
            _grid = _initGameGrid(TOTAL_GRID_ROW, TOTAL_GRID_COL);

            UIExperience.InitializationInterface(); //Will initialize all conmponents and resourcees necessary to strat the game

            GamerHandler.InitializePlayer("AI", AI_CHAR);
            GamerHandler.InitializePlayer(Console.ReadLine(), PLAYER_CHAR);

            UIExperience.DesignGameGrid(_refreshGameGrid()); //initializing new game grid

            //Player can start over compuyter
            _gamer = GamerHandler.Gamers[PLAYER_INDEX];
            


        }



        //TODO get rid of if else and check only at the end if is player turn 
        //chang CHAR or ASSIGN char to the selected player
        private static void _defineGridPosition()
        {
            bool isEmpty = true;
            var playerPosition = UIExperience.PlayerPoistionChoice();
            while (isEmpty)
            {
                
                isEmpty = _cellNotEmpty(playerPosition[0], playerPosition[1]);
                if (isEmpty)
                {
                    UIExperience.DisplayCellNotEmptyMessage($"The selected zone is not empty !Zone ROW: {playerPosition[0]}");
                    playerPosition = UIExperience.PlayerPoistionChoice();
                }
             

            }
            
            _grid[playerPosition[0], playerPosition[1]] = _gamer.PlayerChar;

            _refreshGameGrid();
            UIExperience.DesignGameGrid(_refreshGameGrid()); //initializing new game grid
        }

        private static void _switchPlayerTurn() 
        { 
            if(_gamer == GamerHandler.Gamers[AI_INDEX])
            {
                _gamer = GamerHandler.Gamers[PLAYER_INDEX];
            }
            else
            {
                _gamer = GamerHandler.Gamers[AI_INDEX];
            }


        }

        private static bool _cellNotEmpty(int row, int col)
        {
            return _grid[row, col] > 0;
        }

        private static string _refreshGameGrid()
        {
           
            bool passed = true;
            string header = "";

                for (int i = 0; i < _grid.GetLength(0); i++)
                {

                    for (int j = 0; j < _grid.GetLength(1); j++)
                    {
                        int value = _grid[i, j];
               
                        if (value == BOX_EMPTY_VALUE || i == 0 && j == 0) //i and j are the indexes while the indexes are 0 place a space to create a gapen between the row and header
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
