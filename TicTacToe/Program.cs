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
            bool isPlayerTurn = false;
            string playerName;
            int[,] grid = GameLogic.InitGameGrid(Constant.TOTAL_GRID_ROW, Constant.TOTAL_GRID_COL);
            InitGameSession(grid);

            GameLogic.playedGrids = 0;

            while(true)
            {
                if (GameLogic.playedGrids == Constant.DRAFT)
                {
                    DeclareDraft();
                }
                isPlayerTurn = SwitchPlayerTurn(isPlayerTurn); //player can play first
                DeterminePlayerTurn(grid, isPlayerTurn);
        
                //design the base GRID
                UIExperience.RefreshInterface(grid);

                
                UIExperience.DesignGameGrid(grid); //initializing new game grid
                GameLogic.playedGrids++;
         
            }

        }

        private static void InitGameSession(int[,] grid)
        {
            

            UIExperience.InitializeInterface(); //Will initialize all conmponents and resourcees necessary to strat the game
            GameLogic.PlayerName = Console.ReadLine();
            
            UIExperience.DesignGameGrid(grid); //initializing new game grid

            //Player can start over compuyter
            GameLogic.IsPlayerTurn = true;

        }


        public static void DeclareWinner(int[,] grid)
        { 
            UIExperience.DesignGameGrid(grid);
            
            if (!GameLogic.IsPlayerTurn)
            {
                GameLogic.PlayerName = Constant.AI;
            }
            UIExperience.DisplayWinner(GameLogic.PlayerName);

            UIExperience.EndOfGame();
        }

        public static void DeclareDraft()
        {
            UIExperience.EndOfGame();
        }


        public static void DeterminePlayerTurn(int[,] grid, bool isPlayerTurn)
        {
            int playedRow;
            int playedCol;
            int playerChar = 0;
            if (isPlayerTurn)
            {
                int[] playerPosition = UIExperience.PlayerPoistionChoice();
                bool isNotEmpty = true;

                
                playedRow = playerPosition[0];
                playedCol = playerPosition[1];
                playerChar = Constant.PLAYER_CHAR;
                string zoneNotEmptyMessage = $"The selected zone is not empty !Zone ROW: {playedRow}, COL: {playedCol}";

                while (isNotEmpty)
                {
                    isNotEmpty = GameLogic.CellIsNotEmpty(grid, playedRow, playedCol);
                    if (isNotEmpty)
                    {

                        UIExperience.DisplayCellNotEmptyMessage(zoneNotEmptyMessage);
                        playerPosition = UIExperience.PlayerPoistionChoice();
                        playedRow = playerPosition[0];
                        playedCol = playerPosition[1];
                    }

                }

          
     
            }
            else
            {
                int[] aiPosition = GameLogic.AITurn();
                playedRow = aiPosition[0];
                playedCol = aiPosition[1];
                playerChar = Constant.AI_CHAR;
             
            }


            GameLogic.SetCharPosition(grid, playerChar, playedRow, playedCol);
            GameLogic.IsWinner(grid, playedRow, playedCol);

        }


        public static bool SwitchPlayerTurn(bool isPlayerTurn)
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



    }
}
