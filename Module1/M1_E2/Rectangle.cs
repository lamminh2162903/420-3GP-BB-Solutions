using System;

namespace M1_E2
{
    /// <summary>
    /// La classe Rectangle
    /// </summary>
    class Rectangle : FormeGeometrique
    {
        private double _largeur;
        private double _longueur;
        /// <summary>
        /// La largeur du rectangle
        /// </summary>
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

        /// <summary>
        /// La longueur du rectangle
        /// </summary>
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

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="largeur">La largeur</param>
        /// <param name="longueur">La longueur</param>
        public Rectangle(double largeur, double longueur)
        {
            Largeur = largeur;
            Longueur = longueur;
        }

        /// <summary>
        /// Le périmètre est la somme des longueur et largeur * 2.
        /// </summary>
        /// <returns>Le périmètre</returns>
        public override double CalculerPerimetre()
        {
            return (Largeur + Longueur) * 2;
        }
    }
}
