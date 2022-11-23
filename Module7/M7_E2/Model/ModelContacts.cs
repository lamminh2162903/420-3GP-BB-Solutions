using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Xml;

namespace Model
{
    public class ModelContacts : IEnumerable<Contact>
    {
        private List<Contact> _lesContacts;
        //private int _indiceCourant;
        //public Contact? Courant
        //{
        //    get
        //    {
        //        if (_lesContacts.Count > 0)
        //        {
        //            return _lesContacts[_indiceCourant];
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        //public bool PrecedentExiste
        //{
        //    get
        //    {
        //        return _indiceCourant > 0;
        //    }
        //}

        //public bool ProchainExiste
        //{
        //    get
        //    {
        //        return _indiceCourant < _lesContacts.Count - 1;
        //    }
        //}

        //public int Count
        //{
        //    get
        //    {
        //        return _lesContacts.Count;
        //    }
        //}

        public ModelContacts()
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load(nomFichier);
            ////pathFichier = nomFichier;
            //XmlNodeList contacts = doc.DocumentElement.GetElementsByTagName("contact");
            //_lesContacts = new List<Contact>();
            //foreach (XmlElement c in contacts)
            //{
            //    _lesContacts.Add(new Contact(c));
            //}
            //_indiceCourant = 0;
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
            _lesContacts = new List<Contact>();

            foreach (XmlElement c in contacts)
            {
                _lesContacts.Add(new Contact(c));
            }
//            _indiceCourant = 0;
        }

        public void Add(Contact c)
        {
            _lesContacts.Add(c);
        }

        public void Clear()
        {
            _lesContacts.Clear();
//            _indiceCourant = 0;
        }

        public void AllerAuProchain()
        {
            //if (ProchainExiste)
            //{
            //    _indiceCourant++;
            //}

        }

        public void AllerAuPrecedent()
        {
            //if (PrecedentExiste)
            //{
            //    _indiceCourant--;
            //}
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
            //pathFichier = nomFichier;
            XmlDocument doc = new XmlDocument();
            XmlElement racine = doc.CreateElement("contact");
            doc.AppendChild(racine);
            foreach (Contact c in _lesContacts)
            {
                racine.AppendChild(c.ToXML(doc));
            }
            doc.Save(nomFichier);
        }

        // On utilise l'énumérateur de la liste. Pour que les foreach fonctionnent
        public IEnumerator<Contact> GetEnumerator()
        {
            return _lesContacts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _lesContacts.GetEnumerator();
        }
    }
}