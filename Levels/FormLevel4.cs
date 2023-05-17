using SpaceInvaders.Controllers;
using SpaceInvaders.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders.Levels
{
    public partial class FormLevel4 : Form
    {
        public FormLevel4()
        {
            InitializeComponent();
        }

        private void FormLevel4_Load(object sender, EventArgs e)
        {
            List<Enemigo> enemigos = new();
            for (int x = 120; x <= 750; x += 90)
            {
                for (int y = 70; y <= 350; y += 70)
                {
                    Point p = new(x, y);
                    Point desde = new(x - 30, y);
                    Point hasta = new(x + 30, y);
                    Size s = new(45, 40);
                    PictureBox pb = new();
                    Controls.Add(pb);
                    EnemigoRojo enemigo = new(p, s, pb, 0.3, desde, hasta, 2, 0);
                    enemigos.Add(enemigo);
                }
            }

            _ = new JuegoController(enemigos, new List<Proyectil>(), pbNave, this);

        }
    }
}
