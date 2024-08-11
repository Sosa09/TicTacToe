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
        
        

        public static void Main(string[] args)
        {

            InitGameSession();
            GameLogic.playedGrids = 0;

            while(true)
            {
                if (GameLogic.playedGrids == Constant.DRAFT)
                {
                    DeclareDraft();
                }
                GameLogic.DeterminePlayerTurn();
        
                
                GameLogic.RefreshGameGrid();
                
                UIExperience.DesignGameGrid(GameLogic.RefreshGameGrid()); //initializing new game grid
                GameLogic.playedGrids++;
         
            }

        }

        public static void InitGameSession()
        {
            GameLogic.InitGameGrid(Constant.TOTAL_GRID_ROW, Constant.TOTAL_GRID_COL);

            UIExperience.InitializeInterface(); //Will initialize all conmponents and resourcees necessary to strat the game
            GameLogic.PlayerName = Console.ReadLine();


            UIExperience.DesignGameGrid(GameLogic.RefreshGameGrid()); //initializing new game grid

            //Player can start over compuyter
            GameLogic.IsPlayerTurn = true;



        }


        public static void DeclareWinner()
        {
            UIExperience.DesignGameGrid(GameLogic.RefreshGameGrid());
            
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

    }
}
