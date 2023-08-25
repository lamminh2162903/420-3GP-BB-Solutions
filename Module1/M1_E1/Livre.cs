using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace M1_E1
{
    /// <summary>
    /// La classe livre qui contient les informations sur le livre
    /// </summary>
    class Livre
    {
        private int _nombrePages;  // nécessaire car la propriété implémente une validation

        /// <summary>
        /// Le titre
        /// </summary>
        public string Titre
        {
            private set;
            get;
        }

        /// <summary>
        /// L'auteur du livre
        /// </summary>
        public string Auteur
        {
            private set;
            get;
        }

        /// <summary>
        /// L'éditeur du livre
        /// </summary>
        public string Editeur
        {
            private set;
            get;
        }

        /// <summary>
        /// Le nombre de page du livre. Doit être un nombre plus grand que 0
        /// </summary>
        public int NombrePages
        {
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Le nombre de pages doit être plus grand que 0");
                }
                _nombrePages = value;
            }

            get => _nombrePages;
        }

        /// <summary>
        /// L'année du livre
        /// </summary>
        public int Annee
        {
            set;
            get;
        }

        /// <summary>
        /// Le constructeur du livre. Toutes les valeurs doivent être spécifiées
        /// </summary>
        /// <param name="titre">Le titre du livre</param>
        /// <param name="auteur">L'auteur du livre</param>
        /// <param name="editeur">l'éditeur du livre</param>
        /// <param name="nombrePages">Le nombre de pages, doit être supérieur à 0</param>
        /// <param name="annee">L'année d'édition du livre</param>
        public Livre(string titre, string auteur, string editeur, int nombrePages, int annee)
        {
            Titre = titre;
            Auteur = auteur;
            Editeur = editeur;
            NombrePages = nombrePages;
            Annee = annee;
        }

        /// <summary>
        /// Retourne les informations du livre sous la forme d'une chaîne de caractères.
        /// </summary>
        /// <returns>Les informations sur le livre</returns>
        public override string ToString()
        {
            StringBuilder chaine = new StringBuilder();
            chaine.Append(Titre);
            chaine.Append(", ");
            chaine.Append(Auteur);
            chaine.Append(", ");
            chaine.Append(Editeur);
            chaine.Append(", ");
            chaine.Append(NombrePages.ToString());
            chaine.Append(" pages, ");
            chaine.Append(Annee.ToString());
            chaine.Append(".");
            return chaine.ToString();
        }
    }
}
