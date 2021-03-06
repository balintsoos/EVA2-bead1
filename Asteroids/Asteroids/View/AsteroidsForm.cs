﻿using Asteroids.Model;
using Asteroids.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids.View
{
    public partial class AsteroidsForm : Form
    {
        #region Private fields

        private AsteroidsModel _model;

        private int _rows;
        private int _columns;
        private int _fieldSize;

        #endregion

        #region Constructor

        public AsteroidsForm()
        {
            InitializeComponent();

            _rows = 5;
            _columns = 5;
            _fieldSize = 100;

            _model = new AsteroidsModel(_rows, _columns);
            _model.FieldsChanged += new EventHandler(Model_FieldsChanged);
            _model.TimePassed += new EventHandler<int>(Model_TimePassed);
            _model.GameOver += new EventHandler<int>(Model_GameOver);

            _newGameButton.Click += new EventHandler(AsteroidsForm_NewGame);

            _pauseResumeButton.Click += new EventHandler(AsteroidsForm_PauseResume);

            KeyPreview = true;
            KeyDown += new KeyEventHandler(AsteroidsForm_KeyDown);
        }

        #endregion

        #region Model event handlers

        private void Model_FieldsChanged(object sender, EventArgs e)
        {
            RefreshPanel();
        }

        private void Model_TimePassed(object sender, int time)
        {
            RefreshTime(time);
        }

        private void Model_GameOver(object sender, int time)
        {
            string header = "Game Over";
            string text = "You lived for " + time.ToString() + " seconds";
            MessageBox.Show(text, header, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            InitGame();
        }

        #endregion

        #region Form event handlers

        private void AsteroidsForm_NewGame(object sender, EventArgs e)
        {
            InitGame();
            _pauseResumeButton.Visible = true;
            _timeLabel.Visible = true;
        }

        private void AsteroidsForm_PauseResume(object sender, EventArgs e)
        {
            if (_model.Paused)
            {
                _model.Resume();
                _pauseResumeButton.Text = "Pause";
            }
            else
            {
                _model.Pause();
                _pauseResumeButton.Text = "Resume";
            }
        }

        private void AsteroidsForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    _model.TurnLeft();
                    break;
                case Keys.D:
                    _model.TurnRight();
                    break;
            }
        }

        #endregion

        #region Private Methods

        private void InitPanel()
        {
            _panel.Width = _columns * _fieldSize;
            _panel.Height = _rows * _fieldSize;

            Width = _panel.Width + 40;
            Height = _panel.Height + 100;
        }

        private void RefreshPanel()
        {
            Bitmap bitmap = new Bitmap(_panel.Width, _panel.Height);

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(SystemColors.Control);

            // Render background
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    graphics.DrawImage(Properties.Resources.space, i * _fieldSize, j * _fieldSize, _fieldSize, _fieldSize);
                }
            }

            // Render player
            graphics.DrawImage(Properties.Resources.ship, _model.Player.X * _fieldSize, _model.Player.Y * _fieldSize, _fieldSize, _fieldSize);

            // Render asteroids
            foreach (Coordinate asteroid in _model.Asteroids)
            {
                graphics.DrawImage(Properties.Resources.asteroid, asteroid.X * _fieldSize, asteroid.Y * _fieldSize, _fieldSize, _fieldSize);
            }

            _panel.CreateGraphics().DrawImage(bitmap, 0, 0);
        }

        private void RefreshTime(int time)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(RefreshTime), new object[] { time });
                return;
            }

            _timeLabel.Text = "Time: " + time.ToString();
        }

        private void InitGame()
        {
            InitPanel();

            _model.NewGame();

            _pauseResumeButton.Text = _model.Paused ? "Resume" : "Pause";

            RefreshTime(0);
        }

        #endregion
    }
}
