using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeFacadeDemo.Models;
using TicTacToeFacadeDemo.Presentation;

namespace TicTacToeFacadeDemo.Controller
{
    internal class GameController
    {
        Board _board;
        GameUI _gameUI;
        PlayerMark _currentPlayer;

        public GameController(Board board, GameUI gameui)
        {
            _board = board;
            _gameUI = gameui;
            _currentPlayer = PlayerMark.X;
        }

        public void StartGame()
        {
            bool isGameOver = false;

            while (!isGameOver)
            {
                _gameUI.DisplayBoard(_board.Cells);
                int move = GetValidMove();

                _board.MakeMove(move, _currentPlayer);

                if (CheckWin())
                {
                    _gameUI.DisplayBoard(_board.Cells);
                    _gameUI.DisplayWinner(_currentPlayer);
                    isGameOver = true;
                }
                else if (IsBoardFull())
                {
                    _gameUI.DisplayBoard(_board.Cells);
                    _gameUI.DisplayDraw();
                    isGameOver = true;
                }
                else
                {
                    SwitchPlayer();
                }
            }
        }

        public int GetValidMove()
        {
            bool validMove = false;
            int move = -1;

            while (!validMove)
            {
                move = _gameUI.GetMoveInput(_currentPlayer);
                if (move >= 0 && move < 9)
                {
                    if (_board.IsCellEmpty(move))
                    {
                        validMove = true;
                    }
                    else
                    {
                        _gameUI.DisplayCellFilled();
                    }
                }
                else
                {
                    _gameUI.DisplayInvalidMove();
                }
            }

            return move;
        }

        public bool CheckWin()
        {
            return
                (_board.Cells[0] == _currentPlayer && _board.Cells[1] == _currentPlayer && _board.Cells[2] == _currentPlayer) || 
                (_board.Cells[3] == _currentPlayer && _board.Cells[4] == _currentPlayer && _board.Cells[5] == _currentPlayer) || 
                (_board.Cells[6] == _currentPlayer && _board.Cells[7] == _currentPlayer && _board.Cells[8] == _currentPlayer) || 
                (_board.Cells[0] == _currentPlayer && _board.Cells[3] == _currentPlayer && _board.Cells[6] == _currentPlayer) ||  
                (_board.Cells[1] == _currentPlayer && _board.Cells[4] == _currentPlayer && _board.Cells[7] == _currentPlayer) || 
                (_board.Cells[2] == _currentPlayer && _board.Cells[5] == _currentPlayer && _board.Cells[8] == _currentPlayer) || 
                (_board.Cells[0] == _currentPlayer && _board.Cells[4] == _currentPlayer && _board.Cells[8] == _currentPlayer) || 
                (_board.Cells[2] == _currentPlayer && _board.Cells[4] == _currentPlayer && _board.Cells[6] == _currentPlayer);   
        }

        public bool IsBoardFull()
        {
            foreach (var cell in _board.Cells)
            {
                if (cell == PlayerMark.EMPTY)
                {
                    return false;
                }
            }
            return true;
        }

        private void SwitchPlayer()
        {
            _currentPlayer = (_currentPlayer == PlayerMark.X) ? PlayerMark.O : PlayerMark.X;
        }
    }
}
