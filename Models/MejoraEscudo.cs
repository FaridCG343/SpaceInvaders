using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models
{
    public class MejoraEscudo: Mejora
    {
        public MejoraEscudo(Point pos) : base(new(), pos, Resources.proteger)
        { 
        }

        public override void Activar(Nave nave)
        {
            nave.ActivarEscudo();
        }
    }
}
