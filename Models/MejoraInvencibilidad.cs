using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models
{
    public class MejoraInvencibilidad: Mejora
    {
        public MejoraInvencibilidad(Point pos) : base(new(), pos, Resources.invencivilidad)
        {
        }

        public override void Activar(Nave nave)
        {
            nave.HacerInvulnerable();
        }
    }
}
