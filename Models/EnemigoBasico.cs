using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models
{
    public class EnemigoBasico: Enemigo
    {
        public EnemigoBasico(Point location, Size size, PictureBox pb,double prob, Point desde, Point hasta, int movX, int movY): 
            base(2, location, size, pb, prob, desde, hasta, movX, movY, 5, 20)
        {
            Image = Resources.LargeAlien;
            pb.Image = Image;
        }

    }
}
