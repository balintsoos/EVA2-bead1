﻿namespace Asteroids.View
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
            this._panel = new System.Windows.Forms.Panel();
            this._newGameButton = new System.Windows.Forms.Button();
            this._pauseResumeButton = new System.Windows.Forms.Button();
            this._timeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _panel
            // 
            this._panel.Location = new System.Drawing.Point(12, 41);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(260, 208);
            this._panel.TabIndex = 1;
            // 
            // _newGameButton
            // 
            this._newGameButton.Location = new System.Drawing.Point(12, 12);
            this._newGameButton.Name = "_newGameButton";
            this._newGameButton.Size = new System.Drawing.Size(75, 23);
            this._newGameButton.TabIndex = 2;
            this._newGameButton.Text = "New Game";
            this._newGameButton.UseVisualStyleBackColor = true;
            // 
            // _pauseResumeButton
            // 
            this._pauseResumeButton.Location = new System.Drawing.Point(93, 12);
            this._pauseResumeButton.Name = "_pauseResumeButton";
            this._pauseResumeButton.Size = new System.Drawing.Size(75, 23);
            this._pauseResumeButton.TabIndex = 3;
            this._pauseResumeButton.Text = "Pause / Resume";
            this._pauseResumeButton.UseVisualStyleBackColor = true;
            this._pauseResumeButton.Visible = false;
            // 
            // _timeLabel
            // 
            this._timeLabel.AutoSize = true;
            this._timeLabel.Location = new System.Drawing.Point(174, 17);
            this._timeLabel.Name = "_timeLabel";
            this._timeLabel.Size = new System.Drawing.Size(42, 13);
            this._timeLabel.TabIndex = 4;
            this._timeLabel.Text = "Time: 0";
            this._timeLabel.Visible = false;
            // 
            // AsteroidsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 52);
            this.Controls.Add(this._timeLabel);
            this.Controls.Add(this._pauseResumeButton);
            this.Controls.Add(this._newGameButton);
            this.Controls.Add(this._panel);
            this.Name = "AsteroidsForm";
            this.Text = "Asteroids Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel _panel;
        private System.Windows.Forms.Button _newGameButton;
        private System.Windows.Forms.Button _pauseResumeButton;
        private System.Windows.Forms.Label _timeLabel;
    }
}