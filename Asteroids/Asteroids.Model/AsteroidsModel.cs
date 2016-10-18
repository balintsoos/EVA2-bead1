using Asteroids.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Asteroids.Model
{
    public class AsteroidsModel
    {
        #region Private fields

        private List<Coordinate> _asteroids;
        private Coordinate _player;
        private Board _gameBoard;
        private bool _paused;
        private Timer _timer;
        private int _time;

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
            InitTimer();

            _paused = false;
        }

        public void Pause()
        {
            _paused = true;
        }

        public void Resume()
        {
            _paused = false;
        }

        public void TurnLeft()
        {
            if (!_paused && _player.X > 0)
            {
                _player.X -= 1;

                OnFieldsChanged();
                CheckCollision();
            }
        }

        public void TurnRight()
        {
            if (!_paused && _player.X < _gameBoard.Width - 1)
            {
                _player.X += 1;

                OnFieldsChanged();
                CheckCollision();
            }
        }

        #endregion

        #region Private methods

        private void InitPlayer()
        {
            _player = new Coordinate(0, _gameBoard.Height - 1);
        }

        private void InitAsteroids()
        {
            _asteroids = new List<Coordinate>();
            _asteroids.Add(new Coordinate(1,0));
        }

        private void InitTimer()
        {
            if (_timer != null)
            {
                _timer.Stop();
            }

            _time = 0;
            _timer = new Timer(1000);
            _timer.Elapsed += TimePassed;
            _timer.Start();
        }

        private void TimePassed(object sender, ElapsedEventArgs e)
        {
            _time += 1;
            MoveAsteroids();
            CheckCollision();

            OnFieldsChanged();
        }

        private void CheckCollision()
        {
            foreach (Coordinate asteroid in _asteroids)
            {
                if (asteroid.Equals(_player))
                {
                    OnGameOver();
                    return;
                }
            }
        }

        private void MoveAsteroids()
        {
            DeletePassedAsteroids();

            foreach (Coordinate asteroid in _asteroids)
            {
                asteroid.Y = asteroid.Y + 1;
            }
        }

        private void DeletePassedAsteroids()
        {
            var itemToRemove = _asteroids.SingleOrDefault(a => a.Y >= _gameBoard.Height - 1);
            _asteroids.Remove(itemToRemove);
        }

        #endregion

        #region Events

        public event EventHandler GameOver;

        public event EventHandler FieldsChanged;

        #endregion

        #region Event triggers

        private void OnGameOver()
        {
            _paused = true;
            _timer.Stop();

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
