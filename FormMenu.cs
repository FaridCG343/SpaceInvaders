using SpaceInvaders.Levels;

namespace SpaceInvaders
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            Program.nave = new();
            Program.level = new FormLevel1();
            Program.level.Show();
            Hide();
        }
    }
}