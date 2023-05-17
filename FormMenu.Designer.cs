namespace SpaceInvaders
{
    partial class FormMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            btnJugar = new Button();
            SuspendLayout();
            // 
            // btnJugar
            // 
            btnJugar.Location = new Point(421, 528);
            btnJugar.Margin = new Padding(3, 2, 3, 2);
            btnJugar.Name = "btnJugar";
            btnJugar.Size = new Size(82, 22);
            btnJugar.TabIndex = 0;
            btnJugar.Text = "Jugar";
            btnJugar.UseVisualStyleBackColor = true;
            btnJugar.Click += btnJugar_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.space_background1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(884, 561);
            Controls.Add(btnJugar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormMenu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnJugar;
    }
}