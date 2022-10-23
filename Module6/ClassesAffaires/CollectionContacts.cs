using System.Xml;

namespace Contacts
{

    public class CollectionContacts
    {

        private List<Contact> lesContacts;
        int indiceCourant;

        public Contact Courant
        {
            set;
            get;
        }

        public bool PrecedentExiste
        {
            get;
        }

        public bool ProchainExiste
        {
            get;
         }

        public CollectionContacts(string nomFichier)
        {

        }

        public void AllerAuProchain()
        {

        }

        public void AllerAuPrecedent()
        {

        }

        public void SauvegarderContacts()
        {

        }
    }
}
