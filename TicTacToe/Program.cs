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
        static int[,] _grid;
    

        public static void Main(string[] args)
        {
            InitGameSession();

            while(true)
            {
                DefineGridPosition();

                RefreshGameGrid();
                
                UIExperience.DesignGameGrid(RefreshGameGrid()); //initializing new game grid

         
            }

        }

        private static void InitGameSession()
        {
            _grid = InitGameGrid(Constant.TOTAL_GRID_ROW, Constant.TOTAL_GRID_COL);

            UIExperience.InitializationInterface(); //Will initialize all conmponents and resourcees necessary to strat the game

            GameLogic.InitializePlayer(Constant.AI, Constant.AI_CHAR);
            GameLogic.InitializePlayer(Constant.PLAYER, Constant.PLAYER_CHAR);

            UIExperience.DesignGameGrid(RefreshGameGrid()); //initializing new game grid

            //Player can start over compuyter
            GameLogic.IsPlayerTurn = true;
            


        }


        //TODO get rid of if else and check only at the end if is player turn 
        //chang CHAR or ASSIGN char to the selected player
        private static void DefineGridPosition()
        {
            bool isNotEmpty = true;
            var playerPosition = new int[2];
            var character = Constant.PLAYER_CHAR;

            if (GameLogic.IsPlayerTurn)
            {
                playerPosition = UIExperience.PlayerPoistionChoice();
                
                while (isNotEmpty)
                {
                    isNotEmpty = CellNotEmpty(playerPosition[0], playerPosition[1]);
                    if (isNotEmpty)
                    {
                        UIExperience.DisplayCellNotEmptyMessage($"The selected zone is not empty !Zone ROW: {playerPosition[0]}");
                        playerPosition = UIExperience.PlayerPoistionChoice();
                    }
                   
                }
                GameLogic.IsPlayerTurn = false;
            }              
            else
            {
               
                playerPosition = GameLogic.AITurn();
            
                while (isNotEmpty)
                {
                    isNotEmpty = CellNotEmpty(playerPosition[0], playerPosition[1]);
                    if (isNotEmpty)
                    {
                        playerPosition = GameLogic.AITurn();
                    }
                }
                        character = Constant.AI_CHAR;
                GameLogic.IsPlayerTurn = true;
            }





  


            _grid[playerPosition[0], playerPosition[1]] = character;
   

        }

        private static bool CellNotEmpty(int row, int col)
        {
            return _grid[row, col] > 0;
        }

        private static string RefreshGameGrid()
        {
            UIExperience.RefreshInterface();
         
            string cell = "";

                for (int i = 0; i < _grid.GetLength(0); i++)
                {

                    for (int j = 0; j < _grid.GetLength(1); j++)
                    {
                        int value = _grid[i, j];
               
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
        private static int[,] InitGameGrid(int rows, int cols) 
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
