using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace TicTacToe
{
    /// <summary>
    /// Program class is used for handling logic between ui and database
    /// </summary>
    public class Program
    {
        
        

        public static void Main(string[] args)
        {
            bool isPlayerTurn = new bool();
            string playerName = string.Empty;
            int[,] grid = GameLogic.InitGameGrid(Constant.TOTAL_GRID_ROW, Constant.TOTAL_GRID_COL);
            InitGameSession(grid, ref playerName, ref isPlayerTurn);

            GameLogic.playedGrids = 0;

            while(true)
            {
                if (GameLogic.playedGrids == Constant.DRAFT)
                {
                    DeclareDraft();
                }
                isPlayerTurn = SwitchPlayerTurn(isPlayerTurn); //player can play first
                DeterminePlayerTurm(grid, isPlayerTurn, playerName);
        
                //design the base GRID
                UIExperience.RefreshInterface(grid);

                
                UIExperience.DesignGameGrid(grid); //initializing new game grid
                GameLogic.playedGrids++;
         
            }

        }

        private static void InitGameSession(int[,] grid,ref string playerName, ref bool isPlayerTurn)
        {
            
            
            UIExperience.InitializeInterface(); //Will initialize all conmponents and resourcees necessary to strat the game

            playerName = Console.ReadLine();
            
            UIExperience.DesignGameGrid(grid); //initializing new game grid

            //Player can start over computer
            isPlayerTurn = false;

        }


        private static void DeclareWinner(int[,] grid, string winnerName)
        { 
            UIExperience.DesignGameGrid(grid);

            UIExperience.DisplayWinner(winnerName);

            UIExperience.EndOfGame();
        }

        public static void DeclareDraft()
        {
            UIExperience.EndOfGame();
        }


        private static void DeterminePlayerTurm(int[,] grid, bool isPlayerTurn, string playerName)
        {
            string currentPlayer = Constant.AI;
            int playerChar = Constant.AI_CHAR;
            if(isPlayerTurn)
            {
                currentPlayer = playerName;
                playerChar = Constant.PLAYER_CHAR;
                PlayerGamePlay(grid, playerChar, currentPlayer, UIExperience.PlayerPoistionChoice);

            }
            else
            {
                PlayerGamePlay(grid, playerChar,currentPlayer, GameLogic.AITurn);

            }


        }

        private static void PlayerGamePlay(int[,] grid, int playerChar, string currentPlayer, Func<int[]> playerPoistionChoice)
        {
            int[] currentPlayerPosition = playerPoistionChoice();
            int playedRow = currentPlayerPosition[0]; //0 represents the row TO CONSTANT
            int playedCol = currentPlayerPosition[1]; //1 represenets the col
            
            bool isNotEmpty = true;

            while (isNotEmpty)
            {
                isNotEmpty = GameLogic.CellIsNotEmpty(grid, playedRow, playedCol);
                if (isNotEmpty)
                {
                    UIExperience.DisplayCellNotEmptyMessage(playedRow, playedCol);

                    currentPlayerPosition = playerPoistionChoice();
                    playedRow = currentPlayerPosition[0]; //0 represents the row TO CONSTANT
                    playedCol = currentPlayerPosition[1]; //1 represenets the col
                }

            }


            SetCharPosition(grid, playerChar, playedRow, playedCol);
            if (GameLogic.IsWinner(grid, playedRow, playedCol))
            {
                DeclareWinner(grid, currentPlayer);
            }
        }





        private static bool SwitchPlayerTurn(bool isPlayerTurn)
        {
            if (isPlayerTurn)
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        

        private static void SetCharPosition(int[,] grid, int character, int playedRow, int playedCol)
        {
            grid[playedRow, playedCol] = character;

        }

        //private string SetCcurrentPlayerNamePlayRound(string currentPlayer){
        //  ivoked from switchplayerTurn which will determine the next player that has to make a move
        // return currentPlayer  
        //}
        //private GetCurrentPlayerNamePlayRound()
        //{
        //  return actual player's turn if AI shows AI else shows player's Name
        //}
        //private GetPlayerName()
        //{

        //}

    }
}
