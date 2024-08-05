using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Gamer
    {
        public string Name { get;set; }
        public int Points { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public int PlayerChar { get; set; }
    }
}
