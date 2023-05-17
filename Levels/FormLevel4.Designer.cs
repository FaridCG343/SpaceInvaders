namespace SpaceInvaders.Levels
{
    partial class FormLevel4
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
            pbNave.Image = Properties.Resources.MainShipFullHealth;
            pbNave.Location = new Point(394, 473);
            pbNave.Name = "pbNave";
            pbNave.Size = new Size(50, 50);
            pbNave.SizeMode = PictureBoxSizeMode.StretchImage;
            pbNave.TabIndex = 0;
            pbNave.TabStop = false;
            // 
            // FormLevel4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.space_background4;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(884, 561);
            Controls.Add(pbNave);
            DoubleBuffered = true;
            Name = "FormLevel4";
            Text = "FormLevel4";
            Load += FormLevel4_Load;
            ((System.ComponentModel.ISupportInitialize)pbNave).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbNave;
    }
}