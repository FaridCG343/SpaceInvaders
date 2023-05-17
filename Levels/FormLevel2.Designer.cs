namespace SpaceInvaders.Levels
{
    partial class FormLevel2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLevel2));
            pbNave = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbNave).BeginInit();
            SuspendLayout();
            // 
            // pbNave
            // 
            pbNave.BackColor = Color.Transparent;
            pbNave.Image = Properties.Resources.MainShipFullHealth;
            pbNave.Location = new Point(416, 499);
            pbNave.Name = "pbNave";
            pbNave.Size = new Size(50, 50);
            pbNave.SizeMode = PictureBoxSizeMode.StretchImage;
            pbNave.TabIndex = 0;
            pbNave.TabStop = false;
            // 
            // FormLevel2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.space_background2;
            ClientSize = new Size(884, 561);
            Controls.Add(pbNave);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormLevel2";
            Text = "FormLevel2";
            Load += FormLevel2_Load;
            ((System.ComponentModel.ISupportInitialize)pbNave).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbNave;
    }
}