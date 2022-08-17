using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2
{
    class Livre : IComparable
    {
        public string Titre
        {
            set;
            get;
        }

        public string Auteur
        {
            set;
            get;
        }

        public string Editeur
        {
            set;
            get;
        }

        public int NombrePages
        {
            set;
            get;
        }

        public int Annee
        {
            set;
            get;
        }

        public Livre()
        {
            Titre = "";
            Auteur = "";
            Editeur = "";
            NombrePages = 0;
            Annee = 0;
        }

        public Livre(string titre, string auteur, string editeur, int nombrePages, int annee)
        {
            Titre = titre;
            Auteur = auteur;
            Editeur = editeur;
            NombrePages = nombrePages;
            Annee = annee;
        }

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

        public  int CompareTo(object obj)
        {
            Livre autre = (Livre) obj;
            return Titre.CompareTo(autre.Titre);
        }

    }
}
