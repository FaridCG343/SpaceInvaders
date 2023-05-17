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
    public partial class FormLevel5 : Form
    {
        public FormLevel5()
        {
            InitializeComponent();
        }

        private void FormLevel5_Load(object sender, EventArgs e)
        {
            List<Enemigo> enemigos = new();
            Random rng = new();
            int enemyNum;
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
                    enemyNum = rng.Next(3);
                    Enemigo enemigo;
                    switch (enemyNum)
                    {
                        case 0:
                            enemigo = new EnemigoVerde(p, s, pb, 0.1, desde, hasta, 2, 0);
                            break;
                        case 1:
                            enemigo = new EnemigoAmarillo(p, s, pb, 0.2, desde, hasta, 2, 0);
                            break;
                        case 2:
                            enemigo = new EnemigoRojo(p, s, pb, 0.3, desde, hasta, 2, 0);
                            break;
                        default:
                            enemigo = new EnemigoVerde(p, s, pb, 0.5, desde, hasta, 2, 0);
                            break;
                    }
                    enemigos.Add(enemigo);
                }
            }

            _ = new JuegoController(enemigos, new List<Proyectil>(), pbNave, this);

        }
    }
}
