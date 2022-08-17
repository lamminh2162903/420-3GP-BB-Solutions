using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1_E3
{
    /// <summary>
    /// La classe Carre.
    /// </summary>
    class Carre : Rectangle
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="cote">La taille d'un côté</param>
        public Carre(double cote) : base(cote, cote)
        {
        }
    }
}
