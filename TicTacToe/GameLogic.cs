using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public static class GameLogic
    {
        public static string PlayerName = "";
        public static bool IsPlayerTurn = true;
        public static int playedGrids = 0;
        private static int[,] _grid;

        //TODO REMOVE MAGIC NUMBERS
        public static int[] AITurn()
        {
            int[] ai_poistions = new int[2];
            Random random = new Random();
            ai_poistions[0] = random.Next(1, 4);
            ai_poistions[1] = random.Next(1, 4);
        
            return ai_poistions;

        }


        

        public static void HorizontalWinnerChecker(int[,] grid, int playedRow)
        {

            bool isWinner = true;
            //TODO: check only row where the player has played to gain performance and speed
            int firstValue = grid[playedRow, Constant.FIRST_PLAYABLE_INDEX_GRID];
            //i = 1 represents the first playable indexgrid
            for (int i = Constant.FIRST_PLAYABLE_INDEX_GRID; i < Constant.TOTAL_GRID_COL; i++)
            {
                int nextValue = grid[playedRow, i];

                if (nextValue == Constant.BOX_EMPTY_VALUE || nextValue != firstValue)
                {
                    isWinner = false;
                    break; //break the statement and continue the game cause nothing to compare
                }
                
                



            }

            //TODO: Create function for this
            if (isWinner)
            {
                Program.DeclareWinner();
            }
      
         
            
        
        }

        public static void VerticalWinnerChecker(int[,] grid, int playedCol)
        {

            bool isWinner = true;
            //TODO: check only row where the player has played to gain performance and speed
            int firstValue = grid[Constant.FIRST_PLAYABLE_INDEX_GRID, playedCol];
            //i = 1 represents the first playable indexgrid
            for (int i = Constant.FIRST_PLAYABLE_INDEX_GRID; i < Constant.TOTAL_GRID_ROW; i++)
            {
                int nextValue = grid[i,playedCol];

                if (nextValue == Constant.BOX_EMPTY_VALUE || nextValue != firstValue)
                {
                    isWinner = false;
                    break; //break the statement and continue the game cause nothing to compare
                }
            }
            //TODO: Create function for this
            if (isWinner)
            {
                Program.DeclareWinner();
            }
        }
    
        public static void DiagonalWinnerChecker(int[,] grid, int playedRow, int playedCol)
        {

            int value = grid[playedRow, playedCol];
            int reverseIndex = 3; //TODO REMOVE MAGIC NUMBER
            bool isDiagWinner = true;   
            bool isDiagReverseWinner = true;

            for (int i = Constant.FIRST_PLAYABLE_INDEX_GRID; i < grid.GetLength(0); i++)
            {
                //1,1 and 1,3 not equal then break
                if (value != grid[i,i] )
                {
                    isDiagWinner = false;  
               
                   
                }
                if(value != grid[i, reverseIndex] )
                {
                    isDiagReverseWinner = false;
                    if(!isDiagWinner) //this will help to break if  both left diag and right diag are not equal
                    {
                        break;
                    }
                }


                reverseIndex--;
            }
            if (isDiagWinner || isDiagReverseWinner)
                Program.DeclareWinner();




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
        public static void InitGameGrid(int rows, int cols)
        {
            _grid = new int[rows, cols];
            //TODO: change 2 the a meaningful variable like representing headers row and columns
            for (int i = 0; i < rows; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (j == 0)
                            continue;
                        _grid[i, j] = j;
                    }
                }
                else
                {
                    _grid[i, 0] = i;
                }
            }



        }


        public static void DeterminePlayerTurn()
        {

            if (IsPlayerTurn)
                DefineGridPosition(Constant.PLAYER_CHAR, UIExperience.PlayerPoistionChoice);
            else
                DefineGridPosition(Constant.AI_CHAR, AITurn);

        }



        //TODO get rid of if else and check only at the end if is player turn 
        //chang CHAR or ASSIGN char to the selected player
        private static void DefineGridPosition(int character, Func<int[]> playerPositionChoice)
        {
            bool isNotEmpty = true;

            var playerPosition = playerPositionChoice();
            int playedRow = playerPosition[0];
            int playedCol = playerPosition[1];


            while (isNotEmpty)
            {
                isNotEmpty = CellNotEmpty(playedRow, playedCol);
                if (isNotEmpty)
                {

                    UIExperience.DisplayCellNotEmptyMessage($"The selected zone is not empty !Zone ROW: {playedRow}, COL: {playedCol}"); //HARDCODED ?
                    playerPosition = playerPositionChoice();
                    playedRow = playerPosition[0];
                    playedCol = playerPosition[1];
                }

            }


            _grid[playedRow, playedCol] = character;
            HorizontalWinnerChecker(_grid, playedRow);
            VerticalWinnerChecker(_grid, playedCol);
            DiagonalWinnerChecker(_grid, playedRow, playedCol);
            SwitchPlayerTurn();

        }

        private static void SwitchPlayerTurn()
        {
            if (IsPlayerTurn)
            {
                IsPlayerTurn = false;

            }
            else
            {
                IsPlayerTurn = true;
            }
        }

        private static bool CellNotEmpty(int row, int col)
        {
            return _grid[row, col] > 0;
        }

        public static string RefreshGameGrid()
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

    }
}
