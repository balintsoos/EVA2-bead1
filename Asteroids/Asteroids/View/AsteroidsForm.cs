using Asteroids.Model;
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

        private int _fieldSize;

        #endregion

        #region Constructor

        public AsteroidsForm()
        {
            InitializeComponent();

            _fieldSize = 100;

            _model = new AsteroidsModel(3,3);
            _model.FieldsChanged += new EventHandler(Model_FieldsChanged);
            _model.GameOver += new EventHandler(Model_GameOver);

            _newGameButton.Click += new EventHandler(AsteroidsForm_NewGame);

            KeyPreview = true;
            KeyDown += new KeyEventHandler(AsteroidsForm_KeyDown);
        }

        #endregion

        #region Model event handlers

        private void Model_FieldsChanged(object sender, EventArgs e)
        {
            RefreshPanel();
        }

        private void Model_GameOver(object sender, EventArgs e)
        {
            MessageBox.Show("You Died!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            _model.NewGame();
        }

        #endregion

        #region Form event handlers

        private void AsteroidsForm_NewGame(object sender, EventArgs e)
        {
            _model.NewGame();
        }

        private void AsteroidsForm_Resize(object sender, EventArgs e)
        {
            RefreshPanel();
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

        private void RefreshPanel()
        {
            int numberOfColums = _model.GameBoard.Width;
            int numberOfRows = _model.GameBoard.Height;

            int width = numberOfColums * _fieldSize;
            int height = numberOfRows * _fieldSize;

            Bitmap bitmap = new Bitmap(width, height);

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(SystemColors.Control);

            for (int i = 0; i < numberOfColums; i++)
            {
                for (int j = 0; j < numberOfRows; j++)
                {
                    graphics.DrawImage(Properties.Resources.space, j * _fieldSize, i * _fieldSize, _fieldSize, _fieldSize);
                }
            }

            graphics.DrawImage(Properties.Resources.ship, 2 * _fieldSize, 0 * _fieldSize, _fieldSize, _fieldSize);

            _panel.CreateGraphics().DrawImage(bitmap, 0, 0);
        }

        #endregion
    }
}
