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
            GameLogic.InitGameSession();

            while(true)
            {
                GameLogic.DeterminePlayerTurn();
        
                
                GameLogic.RefreshGameGrid();
                
                UIExperience.DesignGameGrid(GameLogic.RefreshGameGrid()); //initializing new game grid

         
            }

        }


     
    }
}
