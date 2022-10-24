using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Xml;

namespace Contacts
{
    public class CollectionContacts :IEnumerable<Contact>
    {

        private List<Contact> lesContacts;
        private int indiceCourant;
//        private string pathFichier;

        public Contact? Courant
        {
            get
            {
                if (indiceCourant != -1)
                {
                    return lesContacts[indiceCourant];
                }
                else
                {
                    return null;
                }
            }
        }

        public bool PrecedentExiste
        {
            get
            {
                return indiceCourant > 0;
            }
        }

        public bool ProchainExiste
        {
            get
            {
                return indiceCourant != -1 && indiceCourant < lesContacts.Count - 1;
            }
         }

        public int Count
        {
            get
            {
                return lesContacts.Count;
            }
        }

        public CollectionContacts(string nomFichier)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(nomFichier);
            //pathFichier = nomFichier;
            XmlNodeList contacts = doc.DocumentElement.GetElementsByTagName("contact");
            lesContacts = new List<Contact>();
            foreach (XmlElement c in contacts)
            {
                lesContacts.Add(new Contact(c));
            }
            if (lesContacts.Count > 0)
            {
                indiceCourant = 0;
            }
            else
            {
                indiceCourant = -1;
            }
        }

        public void Add(Contact c)
        {
            lesContacts.Add(c);
            indiceCourant = lesContacts.Count - 1;
        }

        public void Clear()
        {
            lesContacts.Clear();
            indiceCourant--;
//            pathFichier = "";
        }

        public void AllerAuProchain()
        {
            if (ProchainExiste)
            {
                indiceCourant++;
            }

        }

        public void AllerAuPrecedent()
        {
            if (PrecedentExiste)
            {
                indiceCourant--;
            }
        }

        public void RetirerCourant()
        {
            // L'indice courant doit être dans la liste
            if (indiceCourant >= 0 && indiceCourant < lesContacts.Count)
            {
                lesContacts.RemoveAt(indiceCourant);
                // On replace l'indice s'il est maintenant à l'extérieur de la liste
                if (indiceCourant > lesContacts.Count - 1)
                {
                    indiceCourant = lesContacts.Count - 1;
                }
            }
        }

        private void ChargerContacts(string nomFichier)
        {
            if (! File.Exists(nomFichier))
            {
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(nomFichier);
            XmlNodeList contacts = doc.DocumentElement.GetElementsByTagName("contact");
            lesContacts = new List<Contact>();
            foreach (XmlElement c in contacts)
            {
                lesContacts.Add(new Contact(c));
            }
            if (lesContacts.Count > 0)
            {
                indiceCourant = 0;
            }
            else
            {
                indiceCourant = -1;
            }
        }

        public void SauvegarderContacts(string nomFichier)
        {
            //pathFichier = nomFichier;
            XmlDocument doc = new XmlDocument();
            XmlElement racine = doc.CreateElement("contact");
            doc.AppendChild(racine);
            foreach (Contact c in lesContacts)
            {
                racine.AppendChild(c.ToXML(doc));
            }
            doc.Save(nomFichier);
        }



        // On utilise l'énumérateur de la liste. Pour que les foreach fonctionnent
        public IEnumerator<Contact> GetEnumerator()
        {
            return lesContacts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return lesContacts.GetEnumerator();
        }
    }
}
