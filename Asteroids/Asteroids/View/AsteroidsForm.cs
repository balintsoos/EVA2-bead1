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

        #endregion

        public AsteroidsForm()
        {
            InitializeComponent();
        }
    }
}
