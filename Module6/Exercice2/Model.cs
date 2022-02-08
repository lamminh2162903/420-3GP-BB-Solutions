using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2
{
    class Model
    {
        private string nomDossier;
        private string fichierXML;
        private XmlDocument document;

        public List<Contact> LesContacts
        {
            private set;
            get;
        }

        public Model()
        {
            nomDossier = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/.contacts";
            fichierXML = nomDossier + "/sauvegarde.xml";

            LesContacts = new List<Contact>();
            document = new XmlDocument();

            if (! Directory.Exists(nomDossier))
            {
                Directory.CreateDirectory(nomDossier);
            }

            if (File.Exists(fichierXML))
            {
                document.Load(fichierXML);
                ChargerXML();
            }
        }

        private void ChargerXML()
        {
            LesContacts.Clear();
            XmlElement? root = document.DocumentElement;
            if (root != null)
            {
                XmlNodeList listeContacts = root.GetElementsByTagName("Contact");
                foreach (XmlElement elementContact in listeContacts)
                {
                    Contact nouveauContact = new Contact(elementContact);
                    LesContacts.Add(nouveauContact);
                }
                LesContacts.Sort();
            }
        }

        internal void SauvegarderDonnees()
        {
            document = new XmlDocument();
            XmlElement root = document.CreateElement("CarnetAdresse");
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

            while (positionContact < LesContacts.Count && unContact.CompareTo(LesContacts[positionContact]) > 0)
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
            SauvegarderDonnees();
        }
    }
}
