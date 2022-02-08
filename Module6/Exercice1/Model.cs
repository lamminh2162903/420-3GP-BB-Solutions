using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1
{
    class Model
    {
        private string fichierXML = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/sauvegarde.xml";
        private XmlDocument document;

        public List<Contact> LesContacts
        {
            private set;
            get;
        }

        public Model()
        {
            LesContacts = new List<Contact>();
            document = new XmlDocument();

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
                    LesContacts.Add(new Contact(elementContact));
                }
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
            LesContacts.Add(unContact);
        }
    }
}
