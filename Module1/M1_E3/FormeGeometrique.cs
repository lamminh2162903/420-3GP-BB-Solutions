namespace M1_E3
{
    /// <summary>
    /// Classe abstraite qui représente une forme géométrique
    /// </summary>
    abstract class FormeGeometrique
    {
        /// <summary>
        /// Permet de calculer le périmètre. La formule varie en fonction de la forme géométrique
        /// </summary>
        /// <returns>Le périmètre</returns>
        public abstract double CalculerPerimetre();
    }
}
