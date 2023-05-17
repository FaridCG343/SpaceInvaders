using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models
{
    public class ProyectilEnemigo: Proyectil
    {
        private bool img1 = true;
        public ProyectilEnemigo(Point posInicial): base (new PictureBox(), 5, posInicial)
        {
            PbProyectil.Image = Resources.ProyectilEnemigo;
        }

        public override void Mover()
        {
            if (img1)
            {
                PbProyectil.Image = Resources.ProyectilEnemigo2;
                img1 = false;
            }
            else
            {
                PbProyectil.Image = Resources.ProyectilEnemigo;
                img1 = true;
            }
            PbProyectil.Top += MovY; 
        }
    }
}
