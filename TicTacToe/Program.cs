using System;

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
            string currentPlayerName = string.Empty;
            Func<int[]> currentPlayerAction = null;
            int currentPlayerChar = 0;
            int[] currentPlayerMove = new int[2]; //2 corresponds to row and col move 1,1
            int playedGridsCount = 0;

            int[,] grid = GameLogic.InitGameGrid(Constant.TOTAL_GRID_ROW, Constant.TOTAL_GRID_COL);

            InitGameSession(grid, ref playerName, ref isPlayerTurn);

            while (true)
            {
                DeterminePlayerTurn(grid, isPlayerTurn, playerName, ref currentPlayerName, ref currentPlayerChar, ref currentPlayerAction);
                PlayerGamePlay(grid, currentPlayerChar, currentPlayerName, currentPlayerAction, ref currentPlayerMove);
                playedGridsCount++;

                //design the base GRID
                UIExperience.RefreshInterface(grid);

                UIExperience.DesignGameInterface(grid, playerName); //initializing new game grid

                if (GameLogic.IsWinner(grid, currentPlayerMove))
                {
                    UIExperience.DisplayFinalResult(Constant.WIN_CODE, grid, currentPlayerName);
                    break;

                }
                else if (playedGridsCount == Constant.DRAFT_VALUE)
                {
                    //Run if if draft
                    UIExperience.DisplayFinalResult(Constant.DRAFT_CODE, grid, "");
                    break;

                }

                isPlayerTurn = GameLogic.SwitchPlayerTurn(isPlayerTurn);

            }
            
            
            if (UIExperience.Rematch())
                Main(new string[0]);
            
        }

        private static void InitGameSession(int[,] grid, ref string playerName, ref bool isPlayerTurn)
        {

            UIExperience.InitializeInterface(); //Will initialize all conmponents and resourcees necessary to strat the game

            playerName = Console.ReadLine();

            UIExperience.DesignGameInterface(grid, playerName); //initializing new game grid

            //Player can start over computer
            isPlayerTurn = true;

        }

        private static void DeterminePlayerTurn(int[,] grid, bool isPlayerTurn, string playerName, ref string currentPlayerName, ref int currentPlayerChar, ref Func<int[]>? currentPlayerAction)
        {
            if (isPlayerTurn)
            {
                currentPlayerName = playerName;
                currentPlayerChar = Constant.PLAYER_CHAR;
                currentPlayerAction = UIExperience.PlayerPoistionChoice;
            }
            else
            {
                currentPlayerName = Constant.AI;
                currentPlayerChar = Constant.AI_CHAR;
                currentPlayerAction = GameLogic.AITurn;
            }
        }

        private static void PlayerGamePlay(int[,] grid, int playerChar, string currentPlayer, Func<int[]> playerPoistionChoice, ref int[] currentPlayerMove)
        {
            currentPlayerMove = playerPoistionChoice();
            int playedRow = currentPlayerMove[0]; //0 represents the row 
            int playedCol = currentPlayerMove[1]; //1 represenets the col

            bool isNotEmpty = true;

            while (isNotEmpty)
            {
                isNotEmpty = GameLogic.CellIsNotEmpty(grid, playedRow, playedCol);
                if (isNotEmpty)
                {
                    UIExperience.DisplayCellNotEmptyMessage(playedRow, playedCol);

                    currentPlayerMove = playerPoistionChoice();
                    playedRow = currentPlayerMove[0]; //0 represents the row 
                    playedCol = currentPlayerMove[1]; //1 represenets the col
                }

            }

            GameLogic.SetCharPosition(grid, playerChar, playedRow, playedCol);
        }

    }
}