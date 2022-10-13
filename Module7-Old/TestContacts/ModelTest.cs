using NUnit.Framework;
using Exercice3;

namespace TestContacts
{
    public class ModelTest
    {
        private Model leModele;
        private Contact[] lesContacts;

        [SetUp]
        public void Setup()
        {
            leModele = new Model();
            lesContacts = new Contact[5];
            lesContacts[0] = new Contact("Simpson", "Homer", "742", "Evergreen");
            lesContacts[1] = new Contact("Simpson", "Bart", "742", "Evergreen");
            lesContacts[2] = new Contact("Simpson", "Maggie", "742", "Evergreen");
            lesContacts[3] = new Contact("Flanders", "Ned", "740", "Evergreen");
            lesContacts[4] = new Contact("Burns", "Charles", "500", "Evergreen");
        }

        [Test]
        public void ListeInitialementVide()
        {
            Assert.AreEqual(0, leModele.LesContacts.Count);
        }

        [Test]
        public void TriSelonNom()
        {
            Contact[] contactsEnOrdreNom = ObtenirOrdreNom();
            leModele.ChoixTri = Model.ModeTri.NOM;
            InsererContacts();

            for (int i=0; i<leModele.LesContacts.Count; i++)
            {
                Assert.AreSame(leModele.LesContacts[i], contactsEnOrdreNom[i]);
            }
        }

        [Test]
        public void TriSelonPrenom()
        {
            Contact[] contactsEnOrdrePrenom = ObtenirOrdrePrenom();
            leModele.ChoixTri = Model.ModeTri.PRENOM;
            InsererContacts();

            for (int i = 0; i < leModele.LesContacts.Count; i++)
            {
                Assert.AreSame(leModele.LesContacts[i], contactsEnOrdrePrenom[i]);
            }
        }

        [Test]
        public void ChangementModeTri()
        {
            Contact[] contactsEnOrdrePrenom = ObtenirOrdrePrenom();
            leModele.ChoixTri = Model.ModeTri.NOM;
            InsererContacts();
            leModele.ChoixTri = Model.ModeTri.PRENOM;

            for (int i = 0; i < leModele.LesContacts.Count; i++)
            {
                Assert.AreSame(leModele.LesContacts[i], contactsEnOrdrePrenom[i]);
            }
        }

        private Contact[] ObtenirOrdreNom()
        {
            Contact[] contactsEnOrdreNom = new Contact[5];
            contactsEnOrdreNom[0] = lesContacts[4];
            contactsEnOrdreNom[1] = lesContacts[3];
            contactsEnOrdreNom[2] = lesContacts[1];
            contactsEnOrdreNom[3] = lesContacts[0];
            contactsEnOrdreNom[4] = lesContacts[2];
            return contactsEnOrdreNom;
        }

        private Contact[] ObtenirOrdrePrenom()
        {
            Contact[] contactsEnOrdrePrenom = new Contact[5];
            contactsEnOrdrePrenom[0] = lesContacts[1];
            contactsEnOrdrePrenom[1] = lesContacts[4];
            contactsEnOrdrePrenom[2] = lesContacts[0];
            contactsEnOrdrePrenom[3] = lesContacts[2];
            contactsEnOrdrePrenom[4] = lesContacts[3];
            return contactsEnOrdrePrenom;
        }

        private void InsererContacts()
        {
            foreach (Contact unContact in lesContacts)
            {
                leModele.AjouterContact(unContact);
            }

        }
    }
}