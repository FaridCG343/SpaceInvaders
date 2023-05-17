using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models
{
    public class EnemigoVerde: Enemigo
    {
        public EnemigoVerde(Point location, Size size, PictureBox pb, double prob, Point desde, Point hasta, int movX, int movY) : 
            base(4, location, size, pb, prob, desde, hasta, movX, movY, 15)
        {
            Image = Resources.green;
            pb.Image = Image;
        }
    }
}
