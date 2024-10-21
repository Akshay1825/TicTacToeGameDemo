using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeFacadeDemo.Controller;
using TicTacToeFacadeDemo.Presentation;

namespace TicTacToeFacadeDemo.Models
{
    internal class Game
    {
        GameController _gameController;
        Board _board;
        GameUI _gameUI;

        public Game()
        {
            _board = new Board();
            _gameUI = new GameUI();
            _gameController = new GameController(_board, _gameUI);
        }

        public void Start()
        {
            _gameController.StartGame();
        }
    }
}
