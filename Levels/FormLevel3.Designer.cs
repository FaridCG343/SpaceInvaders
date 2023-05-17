namespace SpaceInvaders.Levels
{
    partial class FormLevel3
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
            pbNave = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbNave).BeginInit();
            SuspendLayout();
            // 
            // pbNave
            // 
            pbNave.BackColor = Color.Transparent;
            pbNave.ErrorImage = Properties.Resources.MainShipFullHealth;
            pbNave.Image = Properties.Resources.MainShipFullHealth;
            pbNave.Location = new Point(412, 475);
            pbNave.Name = "pbNave";
            pbNave.Size = new Size(50, 50);
            pbNave.SizeMode = PictureBoxSizeMode.StretchImage;
            pbNave.TabIndex = 0;
            pbNave.TabStop = false;
            // 
            // FormLevel3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.space_background3;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(884, 561);
            Controls.Add(pbNave);
            DoubleBuffered = true;
            Name = "FormLevel3";
            Text = "FormLevel3";
            Load += FormLevel3_Load;
            ((System.ComponentModel.ISupportInitialize)pbNave).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbNave;
    }
}