using Asteroids.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Model
{
    public class AsteroidsModel
    {
        #region Private fields

        private List<Coordinate> _asteroids;
        private Coordinate _player;
        private Board _gameBoard;

        #endregion

        #region Constructor

        public AsteroidsModel(int boardWidth, int boardHeight)
        {
            _gameBoard = new Board(boardWidth, boardHeight);
        }

        #endregion

        #region Public properties

        public Board GameBoard
        {
            get { return _gameBoard; }
        }

        public Coordinate Player
        {
            get { return _player; }
        }

        public List<Coordinate> Asteroids
        {
            get { return _asteroids; }
        }

        #endregion

        #region Public methods

        public void NewGame()
        {
            InitPlayer();
            InitAsteroids();
            OnFieldsChanged();
        }

        public void TurnLeft()
        {
            if (_player.X > 0)
            {
                _player.X = _player.X - 1;
                OnFieldsChanged();
            }
        }

        public void TurnRight()
        {
            if (_player.X < _gameBoard.Width - 1)
            {
                _player.X = _player.X + 1;
                OnFieldsChanged();
            }
        }

        #endregion

        #region Private methods

        private void InitPlayer()
        {
            _player = new Coordinate(0, 0);
        }

        private void InitAsteroids()
        {
            _asteroids = new List<Coordinate>();
            _asteroids.Add(new Coordinate(1,0));
        }

        #endregion

        #region Events

        public event EventHandler GameOver;

        public event EventHandler FieldsChanged;

        #endregion

        #region Event triggers

        private void OnGameOver()
        {
            if (GameOver != null)
                GameOver(this, EventArgs.Empty);
        }

        private void OnFieldsChanged()
        {
            if (FieldsChanged != null)
                FieldsChanged(this, EventArgs.Empty);
        }

        #endregion
    }
}
