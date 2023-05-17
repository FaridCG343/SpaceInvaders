using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models
{
    public class ProyectilNave: Proyectil
    {
        public ProyectilNave(Point posInicial): base(new PictureBox(), -5, posInicial)
        {
            PbProyectil.Image = Resources.ProyectilNave;
        }

        public override void Mover()
        {
            PbProyectil.Top += MovY;
        }
    }
}
