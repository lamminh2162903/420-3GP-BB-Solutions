namespace M2_ClassesAffaire
{
    public static class Utilitaires
    {
        /// <summary>
        /// Méthode qui brasse de façon aléatoire un tableau d'entiers
        /// </summary>
        /// <param name="tableau">Le tableau à brasser</param>
        public static void BrasserTableau(int[] tableau)
        {
            Random rng = new Random();
            for (int i = 0; i < tableau.Length; i++)
            {
                int candidat = rng.Next(0, tableau.Length);
                int temp = tableau[candidat];
                tableau[candidat] = tableau[i];
                tableau[i] = temp;
            }
        }
    }
}
