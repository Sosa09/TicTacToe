using System;

namespace TicTacToe
{
    /// <summary>
    /// UserInterface Experience handles all the Output for the user such as refreshing the console to update the grid, displaying the name of the player his points ...
    /// </summary>
    public static class UIExperience
    {
        public static void InitializeInterface()
        {
            GameInstrcution();
            Console.WriteLine();

            Console.Write(Constant.REQUEST_PLAYER_NAME_MESSAGE);
        }

        private static void GameInstrcution()
        {
            Console.WriteLine(Constant.GAME_INSTRUCTIONS);
        }
        //TODO: 
        private static void DisplayGamerInfo(string playerName)
        {
            Console.WriteLine($"Hello {playerName}");
        }

        public static void DisplayCurrentTurnPlayer(string playerName)
        {
            Console.WriteLine($"Your turn: {playerName}");
        }
        public static void DesignGameInterface(int[,] grid, string? playerName)
        {
            Console.Clear();
            DisplayGamerInfo(playerName);
            DisplayCurrentTurnPlayer(playerName);
            string headers = RefreshInterface(grid);
            Console.Write(headers);
            Console.WriteLine();
        }

        public static string RefreshInterface(int[,] grid)
        {
      
            string cell = "";

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int value = grid[i, j];

                    if (value == Constant.BOX_EMPTY_VALUE || i == 0 && j == 0) //i and j are the indexes while the indexes are 0 place a space to create a gapen between the row and header
                        cell += Constant.GAP + Constant.GAP;
                    else
                    {
                        cell += $"{value} ";
                    }
                }
                cell += "\n";
            }
            return cell;
        }

        public static void DisplayFinalResult(int resultCode, int[,] grid, string winnerName = "") 
        {
            Console.Clear();
            string resultText = string.Empty;
            Console.WriteLine(RefreshInterface(grid));

            if (resultCode == Constant.DRAFT_CODE)
            {
                resultText = "DRAFT_VALUE: No one won !";
            }
            else
            {
                resultText = $"WINNER: {winnerName}";
            }
        
            Console.WriteLine(resultText);
        }

        public static int[] PlayerPoistionChoice()
        {
            int[] playerChoice = new int[2];
            Console.WriteLine(Constant.USER_INPUT_ROW_MESSAGE);
            string row = Console.ReadLine();

            Console.WriteLine(Constant.USER_INPUT_COL_MESSAGE);
            string col = Console.ReadLine();

            if(int.TryParse(row, out int convertedRow) && int.TryParse(col, out int convertedCol))
            {
                playerChoice[0] = convertedRow;
                playerChoice[1] = convertedCol;
            }
            else
            {
                Console.WriteLine(Constant.INPUT_NUMBER_ERROR_MESSAGE);
                PlayerPoistionChoice();
            }

            return playerChoice;
        }

        public static void DisplayCellNotEmptyMessage(int playedRow, string message)
        {
            Console.WriteLine(message);
        }

        internal static bool Rematch()
        {
            Console.WriteLine($"Do you want a rematch ? {Constant.REMATCH_CHOICE_TEXT}");
            char k = Console.ReadKey().KeyChar;

            if (k == Constant.REMATCH_KEY_PRESSED) 
            {
                Console.WriteLine("Restarting Game");
                Console.Clear();
                return true;
            }
            Console.ReadKey();
            return false;
        }

        internal static void DisplayCellNotEmptyMessage(int playedRow, int playedCol)
        {
            Console.WriteLine($"The selected zone is not empty !\nZone ROW: {playedRow}, COL: {playedCol}"); //NOT CONSTANT BECAUSSE OF EMBEDED STRINGS
        }
    }
}