using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models
{
    public class EnemigoRojo: Enemigo
    {
        public EnemigoRojo(Point location, Size size, PictureBox pb, double prob, Point desde, Point hasta, int movX, int movY) : 
            base(16, location, size, pb, prob, desde, hasta, movX, movY, 40, 100)
        {
            Image = Resources.red;
            pb.Image = Image;
        }
    }
}
