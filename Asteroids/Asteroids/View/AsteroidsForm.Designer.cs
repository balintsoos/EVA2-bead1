namespace Asteroids.View
{
    partial class AsteroidsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._NewGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _NewGameButton
            // 
            this._NewGameButton.Location = new System.Drawing.Point(12, 12);
            this._NewGameButton.Name = "_NewGameButton";
            this._NewGameButton.Size = new System.Drawing.Size(75, 23);
            this._NewGameButton.TabIndex = 0;
            this._NewGameButton.Text = "New Game";
            this._NewGameButton.UseVisualStyleBackColor = true;
            // 
            // AsteroidsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this._NewGameButton);
            this.Name = "AsteroidsForm";
            this.Text = "Asteroids Game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _NewGameButton;
    }
}