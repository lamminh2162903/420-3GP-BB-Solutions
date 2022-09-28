using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3_E3
{
    /// <summary>
    /// La classe Commande. Ne contient qu'un temps d'exécution.
    /// Le numéro est généré automatiquement.
    /// </summary>
    internal class Commande
    {
        private static object VERROU_NO = new object();  // Objet pour synchroniser le no de commande (si plus d'un thread crée des commandes)

        private static int prochainNumero = 0;  // Pour générer des numéros de commandes uniques automatiquement 

        /// <summary>
        /// Le constructeur
        /// </summary>
        /// <param name="tempsExecution">Le temps d'exécution</param>
        public Commande(int tempsExecution)
        {
            TempExecution = tempsExecution;

            lock (VERROU_NO)
            {
                NoCommande = prochainNumero++;
            }
        }

        /// <summary>
        /// Le temps pour exécuter une commande
        /// </summary>
        public int TempExecution
        {
            private set;
            get;
        }

        /// <summary>
        /// Le numéro de la commande. Est généré de façon automatique
        /// </summary>
        public int NoCommande
        {
            private set;
            get;
        }

    }
}
