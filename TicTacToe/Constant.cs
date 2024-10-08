﻿namespace TicTacToe
{
    public static class Constant
    {
        
        public const string AI = "computer";
        public const int TOTAL_GRID_ROW = 4;
        public const int TOTAL_GRID_COL = 4;
        public const int MAX_AI_GRID_POSITION = 4; 
        public const int MIN_AI_GRID_POSITION = 1;
        public const char PLAYER_CHAR = 'o';
        public const char AI_CHAR = 'x';
        public const int AI_INDEX = 0;
        public const int PLAYER_INDEX = 1;

        public const string BOX_EMPTY_VALUE = "";
        public const string GAP = " ";
        public const int FIRST_PLAYABLE_INDEX_GRID = 1;
        public const int DRAFT_VALUE = 9;
        public const int WIN_CODE = 1;
        public const int DRAFT_CODE = 0;
        public const string REMATCH_OR_GAMEOVER = "y or n";
        public const string GAME_INSTRUCTIONS = "The grid is composed of 3 rows and 3 columns each containing a header from 1 to 3.\n" +
                                                "To place yor value in a certan plaace of the grid begin with the row and finalize with the column.\n " +
                                                "FOR EXAMPLE\n" +

                                                "  1 2 3" +
                                                "\n1" +
                                                "\n2" +
                                                "\n3" +
                                                "\n" +
                                                "let's say you want to pla ce your char on the middeltop so you start with row 1 press enter then column 2 \n\n";
        public const string INPUT_NUMBER_ERROR_MESSAGE = "all fields be from type integer, try again";
        public const string USER_INPUT_COL_MESSAGE = "Enter the column number: ";
        public const string USER_INPUT_ROW_MESSAGE = "Enter the row number: ";
        public const string REQUEST_PLAYER_NAME_MESSAGE = "Enter your name: ";
        public const char REMATCH_KEY_PRESSED = 'y';
        public const int MAX_MOVES = 2;
    }
}
