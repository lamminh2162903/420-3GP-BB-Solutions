namespace M1_E3
{
    /// <summary>
    /// La classe Cercle
    /// </summary>
    class Cercle : FormeGeometrique
    {
        private double _rayon;

        /// <summary>
        /// Le rayon du cercle
        /// </summary>
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

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="rayon">Le rayon du cercle</param>
        public Cercle(double rayon)
        {
            Rayon = rayon;
        }

        /// <summary>
        /// Retourne le périmètre en fonction du rayon
        /// </summary>
        /// <returns>Le primètre</returns>
        public override double CalculerPerimetre()
        {
            return 2 * Math.PI * Rayon;
        }
    }
}
