using System.Text;

namespace M2_ClassesAffaire
{
    /// <summary>
    /// La classe livre qui contient les informations sur le livre
    /// </summary>
    public class Livre : IComparable
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
        /// Retourne la clé du livre. C'est pour la stocker dans un dictionnaire
        /// </summary>
        public string Cle
        {
            get;
            private set;
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
            Cle = Titre + Auteur + Editeur + Annee.ToString();
        }

        /// <summary>
        /// Retourne les inforations du livre sous la forme d'une chaîne de caractères.
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

        /// <summary>
        /// On compare les titres des livres pour les mettre en ordre alphabétique
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Un entier qui compare les titres des livres</returns>
        public int CompareTo(object? obj)
        {
            Livre autre = obj as Livre;
            int resultat = Titre.CompareTo(autre.Titre);
            resultat = resultat == 0 ? Auteur.CompareTo(autre.Auteur) : resultat;
            resultat = resultat == 0 ? Editeur.CompareTo(autre.Editeur) : resultat;
            resultat = resultat == 0 ? Annee - autre.Annee : resultat;
            resultat = resultat == 0 ? NombrePages - autre.NombrePages : resultat;
            return resultat;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Livre)
            {
                return false;
            }
            return Equals((Livre)obj);
        }

        public bool Equals(Livre autre)
        {
            return CompareTo(autre) == 0;
        }

        public override int GetHashCode()
        {
            return Titre.GetHashCode() + Auteur.GetHashCode() + Editeur.GetHashCode() + Annee + NombrePages;
            // return 42;
        }
    }
}
