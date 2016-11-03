using OpenCvSharp;

namespace _7SegMatrixTool
{
    partial class PlayerForm
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
            this.pictureBoxIplScreen = new OpenCvSharp.UserInterface.PictureBoxIpl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIplScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIplScreen
            // 
            this.pictureBoxIplScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxIplScreen.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIplScreen.MinimumSize = new System.Drawing.Size(640, 480);
            this.pictureBoxIplScreen.Name = "pictureBoxIplScreen";
            this.pictureBoxIplScreen.Size = new System.Drawing.Size(656, 518);
            this.pictureBoxIplScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIplScreen.TabIndex = 0;
            this.pictureBoxIplScreen.TabStop = false;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.pictureBoxIplScreen);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(656, 518);
            this.Name = "PlayerForm";
            this.Text = "PlayerForm";
            this.Load += new System.EventHandler(this.PlayerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIplScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIplScreen;

    }
}