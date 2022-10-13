using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestContacts")]

namespace Exercice3
{
    class Model
    {
        public enum ModeTri {NOM, PRENOM};

        private ModeTri _modeActuel;

        private string nomDossier;
        private string fichierXML;
        private XmlDocument document;

        public List<Contact> LesContacts
        {
            private set;
            get;
        }

        public ModeTri ChoixTri
        {
            set
            {
                if (value != _modeActuel)
                {
                    _modeActuel = value;
                    LesContacts.Sort(TrouverComparateur());
                }
            }
            get
            {
                return _modeActuel;
            }
        }

        public Model()
        {
            nomDossier = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/.contacts";
            fichierXML = nomDossier + "/sauvegarde.xml";
            LesContacts = new List<Contact>();
            document = new XmlDocument();
        }


        public void ChargerXML()
        {
            if (!Directory.Exists(nomDossier))
            {
                Directory.CreateDirectory(nomDossier);
            }

            if (File.Exists(fichierXML))
            {
                document.Load(fichierXML);
                LesContacts.Clear();
                XmlElement? root = document.DocumentElement;
                if (root != null)
                {
                    string choixMode = root.GetAttribute("ModeTri");
                    ChoixTri = (ModeTri)Enum.Parse(typeof(ModeTri), choixMode);

                    XmlNodeList listeContacts = root.GetElementsByTagName("Contact");
                    foreach (XmlElement elementContact in listeContacts)
                    {
                        Contact nouveauContact = new Contact(elementContact);
                        LesContacts.Add(nouveauContact);
                    }
                    LesContacts.Sort(TrouverComparateur());
                }
            }
        }

        private IComparer<Contact> TrouverComparateur()
        {
            IComparer<Contact> comparateur = Contact.ORDRE_NOM;
            switch (_modeActuel)
            {
                case ModeTri.NOM:
                    comparateur = Contact.ORDRE_NOM;
                    break;
                case ModeTri.PRENOM:
                    comparateur = Contact.ORDRE_PRENOM;
                    break;
            }
            return comparateur;
        }

        internal void SauvegarderDonnees()
        {
            document = new XmlDocument();
            XmlElement root = document.CreateElement("CarnetAdresse");
            root.SetAttribute("ModeTri", ChoixTri.ToString());
            document.AppendChild(root);
            foreach (Contact unContact in LesContacts)
            {
                root.AppendChild(unContact.ToXML(document));
            }
            document.Save(fichierXML);
        }

        internal void RetirerContact(int indice)
        {
            if (indice >= 0 && indice < LesContacts.Count)
            {
                LesContacts.RemoveAt(indice);
            }
        }

        internal void AjouterContact(Contact unContact)
        {
            int positionContact = 0;

            IComparer<Contact> comparateur = TrouverComparateur();

            while (positionContact < LesContacts.Count && comparateur.Compare(unContact, LesContacts[positionContact]) > 0)
            {
                positionContact++;
            }

            if (positionContact == LesContacts.Count)
            {
                LesContacts.Add(unContact);
            }
            else
            {
                LesContacts.Insert(positionContact, unContact);
            }
        }
    }
}
