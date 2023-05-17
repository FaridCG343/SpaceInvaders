using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models
{
    public abstract class Mejora
    {
        public PictureBox PbMejora { get; set; }
        public int MovY { get; set; }
        public Mejora(PictureBox pbMejora, Point posInicial, Image image) 
        {
            pbMejora.Enabled = false;
            pbMejora.SizeMode = PictureBoxSizeMode.StretchImage;
            pbMejora.BackColor = Color.Transparent;
            pbMejora.Location = posInicial;
            pbMejora.Size = new(25, 25);
            pbMejora.Image = image;
            PbMejora = pbMejora;
            MovY = 5;
        }

        public void Mover()
        {
            PbMejora.Top += MovY;
        }

        public abstract void Activar(Nave nave);
    }
}
