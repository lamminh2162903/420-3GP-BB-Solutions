namespace M1_E3
{
    /// <summary>
    /// Interface pour les formes géométriques qui peuvent être dessinées.
    /// </summary>
    interface IDessinable
    {
        /// <summary>
        /// Ne dessine pas directement la forme mais retourne une représentation sous la forme d'une chaîne
        /// de caractères.
        /// </summary>
        /// <returns>Le dessin de la forme</returns>
        public string DessinerObjet();
    }
}
