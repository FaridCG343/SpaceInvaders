using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models
{
    public class MejoraAtaque: Mejora
    {
        public MejoraAtaque(Point pos) : base(new(), pos, Resources.fortalecer)
        {
        }

        public override void Activar(Nave nave)
        {
            nave.MejoraAtaque();
        }
    }
}
