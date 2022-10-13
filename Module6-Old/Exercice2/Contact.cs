using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Exercice2
{
    class Contact : IComparable<Contact>
    {
        public string Nom
        {
            get;
            set;
        }
        public string Prenom
        {
            get;
            set;
        }
        public string NoCivique
        {
            set;
            get;
        }
        public string Rue
        {
            get;
            set;
        }
        public string PathPhoto
        {
            set;
            get;
        }

        public Contact()
        {
            Nom = "";
            Prenom = "";
            NoCivique = "";
            Rue = "";
            PathPhoto = "NoImage.png";
        }

        public Contact(string nom, string prenom, string no, string rue) : this()
        {
            Nom = nom;
            Prenom = prenom;
            NoCivique = no;
            Rue = rue;
        }

        public Contact(XmlElement elem) : this()
        {
            Nom = elem.GetAttribute("Nom");
            Prenom = elem.GetAttribute("Prenom");
            NoCivique = elem.GetAttribute("NoCivique");
            Rue = elem.GetAttribute("Rue");
            PathPhoto = elem.GetAttribute("PathPhoto");
        }

        public XmlElement ToXML(XmlDocument doc)
        {
            XmlElement element = doc.CreateElement("Contact");
            element.SetAttribute("Nom", Nom);
            element.SetAttribute("Prenom", Prenom);
            element.SetAttribute("NoCivique", NoCivique);
            element.SetAttribute("Rue", Rue);
            element.SetAttribute("PathPhoto", PathPhoto);
            return element;
        }

        public int CompareTo(Contact? other)
        {
            int valeurComparaison = 0;
            if (other != null)
            {
                valeurComparaison = Nom.CompareTo(other.Nom);
                valeurComparaison = valeurComparaison == 0 ? Prenom.CompareTo(other.Prenom) : valeurComparaison;
                valeurComparaison = valeurComparaison == 0 ? Rue.CompareTo(other.Rue) : valeurComparaison;
                valeurComparaison = valeurComparaison == 0 ? Nom.CompareTo(other.NoCivique) : valeurComparaison;
            }
            return valeurComparaison;
        }
    }
}
