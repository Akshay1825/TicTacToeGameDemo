using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeFacadeDemo.Models;

namespace TicTacToeFacadeDemo.Presentation
{
    internal class GameUI
    {
        public void DisplayBoard(PlayerMark[] board)
        {
            Console.Clear();
            for (int i = 0; i < board.Length; i++)
            {
                char displayChar = GetDisplayChar(board[i]);
                Console.Write(displayChar + " ");

                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        public char GetDisplayChar(PlayerMark mark)
        {
            return mark == PlayerMark.X ? 'X' : mark == PlayerMark.O ? 'O' : '-';
        }

        public int GetMoveInput(PlayerMark player)
        {
            Console.WriteLine($"Player {GetDisplayChar(player)}, enter the position from (1-9):");
            return int.Parse(Console.ReadLine()) - 1;
        }

        public void DisplayWinner(PlayerMark player)
        {
            Console.WriteLine($"Player {GetDisplayChar(player)} is Winner");
        }

        public void DisplayDraw()
        {
            Console.WriteLine("Match is Draw");
        }

        public void DisplayInvalidMove()
        {
            Console.WriteLine("Invalid move.Please Try again");
        }

        public void DisplayCellFilled()
        {
            Console.WriteLine("Cell is already filled.Please Try again");
        }
    }
}
