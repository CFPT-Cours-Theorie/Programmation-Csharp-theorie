namespace Solitaire.Views
{
    partial class Temp
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
            picBx_imgTest = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picBx_imgTest).BeginInit();
            SuspendLayout();
            // 
            // picBx_imgTest
            // 
            picBx_imgTest.BorderStyle = BorderStyle.FixedSingle;
            picBx_imgTest.Image = Properties.Resources.Clubs_10;
            picBx_imgTest.Location = new Point(145, 83);
            picBx_imgTest.Name = "picBx_imgTest";
            picBx_imgTest.Size = new Size(184, 172);
            picBx_imgTest.SizeMode = PictureBoxSizeMode.Zoom;
            picBx_imgTest.TabIndex = 0;
            picBx_imgTest.TabStop = false;
            picBx_imgTest.Paint += picBx_imgTest_Paint;
            // 
            // Temp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 475);
            Controls.Add(picBx_imgTest);
            MaximizeBox = false;
            Name = "Temp";
            Text = "Temp";
            Load += Temp_Load;
            ((System.ComponentModel.ISupportInitialize)picBx_imgTest).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picBx_imgTest;
    }
}