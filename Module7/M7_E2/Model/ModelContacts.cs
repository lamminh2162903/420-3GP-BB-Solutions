using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Xml;

namespace Model
{
    public class ModelContacts : IEnumerable<Contact>
    {
        public List<Contact> LesContacts
        {
            private set;
            get;
        }
 

        public ModelContacts()
        {
            LesContacts = new List<Contact>();
        }

        public void ChargerContacts(string nomFichier)
        {
            if (!File.Exists(nomFichier))
            {
                throw new FileNotFoundException("Le fichier n'existe pas");
            }
            
            XmlDocument doc = new XmlDocument();
            doc.Load(nomFichier);
            XmlNodeList contacts = doc.DocumentElement.GetElementsByTagName("contact");
            LesContacts = new List<Contact>();

            foreach (XmlElement c in contacts)
            {
                LesContacts.Add(new Contact(c));
            }
        }

        public void Add(Contact c)
        {
            LesContacts.Add(c);
        }

        public void Clear()
        {
            LesContacts.Clear();
        }

        public void RetirerCourant()
        {
            // L'indice courant doit être dans la liste
            //if (_indiceCourant >= 0 && _indiceCourant < _lesContacts.Count)
            //{
            //    _lesContacts.RemoveAt(_indiceCourant);
            //    // On replace l'indice s'il est maintenant à l'extérieur de la liste
            //    if (_indiceCourant > _lesContacts.Count - 1)
            //    {
            //        _indiceCourant = _lesContacts.Count - 1;
            //    }
            //}
        }

        public void SauvegarderContacts(string nomFichier)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement racine = doc.CreateElement("contact");
            doc.AppendChild(racine);
            foreach (Contact c in LesContacts)
            {
                racine.AppendChild(c.ToXML(doc));
            }
            doc.Save(nomFichier);
        }

        // On utilise l'énumérateur de la liste. Pour que les foreach fonctionnent
        public IEnumerator<Contact> GetEnumerator()
        {
            return LesContacts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return LesContacts.GetEnumerator();
        }
    }
}