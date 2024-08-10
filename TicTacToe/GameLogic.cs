﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public static class GameLogic
    {
        public static bool IsPlayerTurn = true;
        public static string PlayerName = "";
        /// <summary>
      
        /// </summary>
        /// <param name="playerName">represents the player name</param>
        public static void InitializePlayer(string playerName, int playerChar )
        {
            
        }


        public static int[] AITurn()
        {
            int[] ai_poistions = new int[2];
            Random random = new Random();
            ai_poistions[0] = random.Next(1, 4);
            ai_poistions[1] = random.Next(1, 4);
            //TODO: check if position is already taken
            return ai_poistions;

        }

        public static int[] PlayerTurn()
        {
            throw new NotImplementedException();
        }

        private static void DeclareWinner()
        {
            if ( !IsPlayerTurn )
            {
                PlayerName = "Computer"; 
            }
            UIExperience.DisplayWinner(PlayerName);
            Console.ReadKey();
        }

        public static void HorizontalWinnerChecker(int[,] _grid, int playedRow)
        {

            bool isWinner = true;
            //TODO: check only row where the player has played to gain performance and speed
            int firstValue = _grid[playedRow, Constant.FIRST_PLAYABLE_INDEX_GRID];
            //i = 1 represents the first playable indexgrid
            for (int i = Constant.FIRST_PLAYABLE_INDEX_GRID; i < Constant.TOTAL_GRID_COL; i++)
            {
                int nextValue = _grid[playedRow, i];

                if (nextValue == Constant.BOX_EMPTY_VALUE || nextValue != firstValue)
                {
                    isWinner = false;
                    break; //break the statement and continue the game cause nothing to compare
                }
                
                



            }

            //TODO: Create function for this
            if (isWinner)
            {
                DeclareWinner();
            }
      
         
            
        
        }

        public static void VerticalWinnerChecker(int[,] _grid, int playedCol)
        {

            bool isWinner = true;
            //TODO: check only row where the player has played to gain performance and speed
            int firstValue = _grid[Constant.FIRST_PLAYABLE_INDEX_GRID, playedCol];
            //i = 1 represents the first playable indexgrid
            for (int i = Constant.FIRST_PLAYABLE_INDEX_GRID; i < Constant.TOTAL_GRID_ROW; i++)
            {
                int nextValue = _grid[i,playedCol];

                if (nextValue == Constant.BOX_EMPTY_VALUE || nextValue != firstValue)
                {
                    isWinner = false;
                    break; //break the statement and continue the game cause nothing to compare
                }





            }

            //TODO: Create function for this
            if (isWinner)
            {
                DeclareWinner();
            }




        }
    
        public static void DiagonalWinnerChecker(int[,] _grid, int playedRow, int playedCol)
        {

            int value = _grid[playedRow, playedCol];
            int reverseIndex = 3; //TODO REMOVE MAGIC NUMBER
            bool isDiagWinner = true;   
            bool isDiagReverseWinner = true;

            for (int i = Constant.FIRST_PLAYABLE_INDEX_GRID; i < _grid.GetLength(0); i++)
            {
                //1,1 and 1,3 not equal then break
                if (value != _grid[i,i] )
                {
                    isDiagWinner = false;  
               
                   
                }
                if(value != _grid[i, reverseIndex] )
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
                DeclareWinner();




        }
    }
}
