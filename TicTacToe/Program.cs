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
            string currentPlayerChar = string.Empty;
            int[] currentPlayerMove = new int[Constant.MAX_MOVES]; //2 corresponds to row and col move 1,1
            int playedGridsCount = 0;
            int endGameCode = 0;

            string[,] grid = GameLogic.InitGameGrid(Constant.TOTAL_GRID_ROW, Constant.TOTAL_GRID_COL);

            InitGameSession(grid, ref playerName, ref isPlayerTurn);

            while (true)
            {
                DeterminePlayerTurn(isPlayerTurn, playerName, ref currentPlayerName, ref currentPlayerChar, ref currentPlayerAction);
                currentPlayerMove = GetValidPlayerPosition(grid, currentPlayerChar, currentPlayerAction);
                GameLogic.SetCharPosition(grid, currentPlayerChar, currentPlayerMove[0], currentPlayerMove[1]);
                playedGridsCount++;

                //design the base GRID
                UIExperience.RefreshInterface(grid);

                UIExperience.DesignGameInterface(grid, playerName); //initializing new game grid

                if (GameLogic.IsWinner(grid, currentPlayerMove))
                {
                    endGameCode = Constant.WIN_CODE;
                    break;

                }
                else if (playedGridsCount == Constant.DRAFT_VALUE)
                {
                    //Run if if draft
                    endGameCode = Constant.DRAFT_CODE;
                    currentPlayerName = "";               
                    break;

                }

                isPlayerTurn = GameLogic.SwitchPlayerTurn(isPlayerTurn);

            }

            UIExperience.DisplayFinalResult(endGameCode, grid, currentPlayerName); //currentPlayerName can be empty only if it is a draft
            if (UIExperience.Rematch())
                Main(new string[0]);
            
        }

        private static void InitGameSession(string[,] grid, ref string playerName, ref bool isPlayerTurn)
        {
            UIExperience.InitializeInterface(); //Will initialize all conmponents and resourcees necessary to strat the game

            playerName = Console.ReadLine();

            UIExperience.DesignGameInterface(grid, playerName); //initializing new game grid

            //Player can start over computer
            isPlayerTurn = true;
        }

        private static void DeterminePlayerTurn(bool isPlayerTurn, string playerName, ref string currentPlayerName, ref string currentPlayerChar, ref Func<int[]>? currentPlayerAction)
        {
            if (isPlayerTurn)
            {
                currentPlayerName = playerName;
                currentPlayerChar = Constant.PLAYER_CHAR.ToString();
                currentPlayerAction = UIExperience.PlayerPoistionChoice;
            }
            else
            {
                currentPlayerName = Constant.AI;
                currentPlayerChar = Constant.AI_CHAR.ToString();
                currentPlayerAction = GameLogic.AITurn;
            }
        }

        private static int[] GetValidPlayerPosition(string[,] grid, string playerChar, Func<int[]> playerPostionChoice)
        {
            int[] currentPlayerMove = playerPostionChoice();
            int playedRow = currentPlayerMove[0]; //0 represents the row 
            int playedCol = currentPlayerMove[1]; //1 represenets the col

            bool isNotEmpty = true;

            while (isNotEmpty)
            {
                isNotEmpty = GameLogic.CellIsNotEmpty(grid, playedRow, playedCol);
                if (isNotEmpty)
                {
                    UIExperience.DisplayCellNotEmptyMessage(playedRow, playedCol);

                    currentPlayerMove = playerPostionChoice();
                    playedRow = currentPlayerMove[0]; //0 represents the row 
                    playedCol = currentPlayerMove[1]; //1 represenets the col
                }

            }
            return currentPlayerMove;
            
        }

    }
}