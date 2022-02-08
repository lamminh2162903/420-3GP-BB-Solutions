using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Exercice3
{
    class ViewModel : INotifyPropertyChanged
    {
        private Model leModele;
        private Contact contactConstruction;
        private Contact contactActuel;
        private int indiceActuel = -1;
        private IList<Contact> lesPersonnes;

        public event PropertyChangedEventHandler? PropertyChanged;


        public string NomContact
        {
            get
            {
                return contactActuel.Nom;
            }

            set
            {
                contactActuel.Nom = value;
                OnPropertyChange("NomContact");
                if (contactActuel != contactConstruction)
                {
                    leModele.SauvegarderDonnees();
                }
            }
        }

        public string PrenomContact
        {
            get
            {
                return contactActuel.Prenom;
            }

            set
            {
                contactActuel.Prenom = value;
                OnPropertyChange("PrenomContact");
                if (contactActuel != contactConstruction)
                {
                    leModele.SauvegarderDonnees();
                }
            }
        }

        public String NoCiviqueContact
        {
            get
            {
                return contactActuel.NoCivique;
            }

            set
            {
                contactActuel.NoCivique = value;
                OnPropertyChange("NoCiviqueContact");
                if (contactActuel != contactConstruction)
                {
                    leModele.SauvegarderDonnees();
                }
            }
        }

        public String RueContact
        {
            get
            {
                return contactActuel.Rue;
            }

            set
            {
                contactActuel.Rue = value;
                OnPropertyChange("RueContact");
                if (contactActuel != contactConstruction)
                {
                    leModele.SauvegarderDonnees();
                }
            }
        }

        public ObservableCollection<string> ModesTri
        {
            get;
        }

        public string ChoixTri
        {
            set
            {
                leModele.ChoixTri = Enum.Parse<Model.ModeTri>(value);
                if (indiceActuel != -1)
                {
                    indiceActuel = lesPersonnes.IndexOf(contactActuel);
                }

            }
            get
            {
                return leModele.ChoixTri.ToString();
            }
        }

        internal bool EstNouveauContact()
        {
            return contactConstruction == contactActuel;
        }

        internal bool ContactEstDansListe()
        {
            return contactActuel != contactConstruction;
        }

        public string PathPhotoContact
        {
            get
            {
                return contactActuel.PathPhoto;
            }

            set
            {
                contactActuel.PathPhoto = value;
                OnPropertyChange("PathPhotoContact");
                if (contactActuel != contactConstruction)
                {
                    leModele.SauvegarderDonnees();
                }
            }
        }



        public ViewModel()
        {
            leModele = new Model();
            leModele.ChargerXML();
            contactConstruction = new Contact("", "", "", "");            // Dans le ViewModel car lié à une décision d'interface
            contactActuel = contactConstruction;
            lesPersonnes = leModele.LesContacts;
            ModesTri = new ObservableCollection<string>();
            
            foreach (Model.ModeTri mode in Enum.GetValues<Model.ModeTri>())
            {
                ModesTri.Add(mode.ToString());
            }

            if (lesPersonnes.Count > 0)
            {
                indiceActuel = 0;
                contactActuel = lesPersonnes[indiceActuel];
            }
        } 


        internal void AllerAuPrecedent()
        {
            if (contactActuel != contactConstruction && indiceActuel > 0)
            {
                indiceActuel = indiceActuel - 1;
                contactActuel = lesPersonnes[indiceActuel];
                UpdateContact();
            }
        }

        internal void AllerAuSuivant()
        {
            if (contactActuel != contactConstruction && indiceActuel < lesPersonnes.Count - 1)
            {
                indiceActuel = indiceActuel + 1;
                contactActuel = lesPersonnes[indiceActuel];
                UpdateContact();
            }
        }

        private void UpdateContact()
        {
            OnPropertyChange("NomContact");
            OnPropertyChange("PrenomContact");
            OnPropertyChange("NoCiviqueContact");
            OnPropertyChange("RueContact");
            OnPropertyChange("PathPhotoContact");
        }


        internal void RetirerActuel()
        {
            if (indiceActuel < lesPersonnes.Count && indiceActuel != -1)
            {
                leModele.RetirerContact(indiceActuel);
                if (lesPersonnes.Count == 0)
                {
                    indiceActuel = -1;
                    contactActuel = contactConstruction;
                }
                else if (indiceActuel < lesPersonnes.Count)
                {
                    contactActuel = lesPersonnes[indiceActuel];
                }
                else
                {
                    indiceActuel = lesPersonnes.Count - 1;
                    contactActuel = lesPersonnes[indiceActuel];
                }
                leModele.SauvegarderDonnees();
                UpdateContact();
            }
        }

        internal bool ProchainPossible()
        {
            return indiceActuel != -1 && indiceActuel < lesPersonnes.Count - 1;
        }

        internal bool PrecedentPossible()
        {
            return  indiceActuel > 0;
        }

        internal void AjouterContact()
        {
            leModele.AjouterContact(contactConstruction);
            contactConstruction = new Contact("", "", "", "");
            leModele.SauvegarderDonnees();
            indiceActuel = lesPersonnes.Count - 1;
            contactActuel = lesPersonnes[indiceActuel];
            UpdateContact();
        }

        internal void CreerNouveauContact()
        {
            contactConstruction = new Contact("", "", "", "");
            contactActuel = contactConstruction;
            indiceActuel = -1;
            UpdateContact();
        }

        public void OnPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
