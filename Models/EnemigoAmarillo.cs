using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models
{
    public class EnemigoAmarillo: Enemigo
    {
        public EnemigoAmarillo(Point location, Size size, PictureBox pb, double prob, Point desde, Point hasta, int movX, int movY) :
            base(8, location, size, pb, prob, desde, hasta, movX, movY, 20, 50)
        {
            Image = Resources.yellow;
            pb.Image = Image;
        }
    }
}
