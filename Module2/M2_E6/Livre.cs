using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice6
{
    public class Livre : IComparable<Livre>, IEquatable<Livre>
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

        public  int CompareTo(Livre obj)
        {
            int resultat = Titre.CompareTo(obj.Titre);
            resultat = resultat == 0 ? Auteur.CompareTo(obj.Auteur) : resultat;
            resultat = resultat == 0 ? Editeur.CompareTo(obj.Editeur) : resultat;
            resultat = resultat == 0 ? Annee - obj.Annee : resultat;
            resultat = resultat == 0 ? NombrePages - obj.NombrePages : resultat;
            return resultat;
        }

        public override bool Equals(Object obj)
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
           // return Titre.GetHashCode() + Auteur.GetHashCode() + Editeur.GetHashCode() + Annee + NombrePages;
           return 42;
        }


    }
}
