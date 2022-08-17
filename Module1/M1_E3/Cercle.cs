using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_2
{
    class Cercle : FormeGeometrique
    {
        private double _rayon;
        public double Rayon
        {
            get 
            {
                return _rayon;
            }
            
            private set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("Valeur non positive");
                }
                _rayon = value;
            }
        }

        public Cercle (double rayon)
        {
            Rayon = rayon;
        }


        public override double CalculerPerimetre()
        {
            return  2 * Math.PI * Rayon;
        }
    }
}
