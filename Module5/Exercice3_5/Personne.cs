using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Exercice3
{
    class Personne : INotifyPropertyChanged
    {
        private static int prochainNumero = 0;

        private string _pathPhoto;

        public event PropertyChangedEventHandler PropertyChanged;

        public int NoClient
        {
            get;
            set;
        }
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
            set {
                    _pathPhoto = value;
                    OnPropertyChange();
                }

            get {
                    return _pathPhoto;
                }
        }

        public Personne()
        {
            NoClient = prochainNumero++;
            PathPhoto = "NoImage.png";
        }

        public Personne(string nom, string prenom, string no, string rue) : this()
        {
            Nom = nom;
            Prenom = prenom;
            NoCivique = no;
            Rue = rue;
        }

        public Personne(XmlElement elem) : this()
        {
            Nom = elem.GetAttribute("Nom");
            Prenom = elem.GetAttribute("Prenom");
            NoCivique = elem.GetAttribute("NoCivique");
            Rue = elem.GetAttribute("Rue");
            PathPhoto = elem.GetAttribute("PathPhoto");
        }


        public XmlElement ToXML(XmlDocument doc)
        {
            XmlElement element = doc.CreateElement("Personne");
            element.SetAttribute("Nom", Nom);
            element.SetAttribute("Prenom", Prenom);
            element.SetAttribute("NoCivique", NoCivique);
            element.SetAttribute("Rue", Rue);
            element.SetAttribute("PathPhoto", PathPhoto);
            return element;
        }

        public void OnPropertyChange(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
