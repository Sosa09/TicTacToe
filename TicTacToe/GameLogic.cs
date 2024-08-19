using System;

namespace TicTacToe
{
    public static class GameLogic
    {
        public static int[] AITurn()
        {
            int[] ai_poistions = new int[2];

            Random random = new Random();

            for (int i = 0; i < ai_poistions.Length; i++)
                ai_poistions[i] = random.Next(Constant.MIN_AI_GRID_POSITION, Constant.MAX_AI_GRID_POSITION);
 
            return ai_poistions;

        }

        private static bool IsHorizontalWinner(int[,] grid, int playedRow)
        {
            bool isWinner = true;

            int firstValue = grid[playedRow, Constant.FIRST_PLAYABLE_INDEX_GRID];
            
            for (int i = Constant.FIRST_PLAYABLE_INDEX_GRID; i < Constant.TOTAL_GRID_COL; i++)
            {
                int nextValue = grid[playedRow, i];

                if (nextValue == Constant.BOX_EMPTY_VALUE || nextValue != firstValue)
                {
                    isWinner = false;
                    break; 
                }
            }
            return isWinner;        
        }

        private static bool IsVerticalWinner(int[,] grid, int playedCol)
        {

            bool isWinner = true;

            int firstValue = grid[Constant.FIRST_PLAYABLE_INDEX_GRID, playedCol];

            for (int i = Constant.FIRST_PLAYABLE_INDEX_GRID; i < Constant.TOTAL_GRID_ROW; i++)
            {
                int nextValue = grid[i,playedCol];

                if (nextValue == Constant.BOX_EMPTY_VALUE || nextValue != firstValue)
                {
                    isWinner = false;
                    break; 
                }
            }            
            return isWinner;
        }
    
        public static bool IsDiagonalWinner(int[,] grid, int playedRow, int playedCol)
        {
            int value = grid[playedRow, playedCol];
            int reverseIndex = grid.GetLength(0) - 1;
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
            return isDiagWinner || isDiagReverseWinner;
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
        public static int[,] InitGameGrid(int rows, int cols)
        {
            int[,] grid = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (j == 0) //ignore first element of the array whcih is the upperleft int[0,0]  
                            continue;
                        grid[i, j] = j;
                    }
                }
                else
                {
                    grid[i, 0] = i;
                }
            }

            return grid;
        }

        public static bool IsWinner(int[,] grid, int[] currentPlayerMove)
        {
            int playedRow = currentPlayerMove[0];
            int playedCol = currentPlayerMove[1];
            if (IsHorizontalWinner(grid, playedRow) || IsVerticalWinner(grid, playedCol) || IsDiagonalWinner(grid, playedRow, playedCol))
            {
                return true;
            }
            
            return false;            
        }

        public static bool CellIsNotEmpty(int[,] grid, int row, int col)
        {
            return grid[row, col] > 0;
        }

        public static bool SwitchPlayerTurn(bool isPlayerTurn)
        {
            return isPlayerTurn == false ? true : false;
        }

        public static void SetCharPosition(int[,] grid, int character, int playedRow, int playedCol)
        {
            grid[playedRow, playedCol] = character;
        }
    }
}
