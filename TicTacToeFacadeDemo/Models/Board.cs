using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeFacadeDemo.Models
{
    internal class Board
    {
        public PlayerMark[] Cells { get; set; }

        public Board()
        {
            Cells = new PlayerMark[9];
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                Cells[i] = PlayerMark.EMPTY;
            }
        }

        public bool IsCellEmpty(int index)
        {
            return Cells[index] == PlayerMark.EMPTY;
        }

        public void MakeMove(int index, PlayerMark player)
        {
            if (IsCellEmpty(index))
            {
                Cells[index] = player;
            }
        }
    }
}
    
