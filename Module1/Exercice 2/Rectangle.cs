using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_2
{
    class Rectangle : FormeGeometrique, IDessinable
    {
        private double _largeur;
        private double _longueur;
        public double Largeur
        {
            get 
            {
                return _largeur;
            }
            
            private set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("Valeur non positive");
                }
                _largeur = value;
            }
        }

        public double Longueur
        {
            get
            {
                return _longueur;
            }

            private set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("Valeur non positive");
                }
                _longueur = value;
            }
        }

        public Rectangle(double largeur, double longueur)
        {
            Largeur = largeur;
            Longueur = longueur;
        }

        public override double CalculerPerimetre()
        {
            return Largeur * 2 + Longueur * 2;
        }

        public void DessinerObjet()
        {
            int longueur = (int) Math.Ceiling(Longueur);
            int largeur = (int)Math.Ceiling(Largeur);

            for (int i=0; i<longueur; i++)
            {
                for (int j=0; j<largeur; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
}
