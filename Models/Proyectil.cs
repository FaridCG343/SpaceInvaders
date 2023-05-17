using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models
{
    
    public abstract class Proyectil
    {
        protected PictureBox PbProyectil { get; set; }
        protected int MovY { get; set; }

        public Proyectil(PictureBox pbProyectil, int MovX, Point posInicial)
        {
            pbProyectil.Enabled = false;
            pbProyectil.SizeMode = PictureBoxSizeMode.StretchImage;
            pbProyectil.BackColor = Color.Transparent;
            pbProyectil.Location = posInicial;
            pbProyectil.Size = new(15, 25);
            this.PbProyectil = pbProyectil;
            this.MovY = MovX;
        }

        public PictureBox GetPictureBox()
        {
            return PbProyectil;
        }
        public abstract void Mover();
    }
}
