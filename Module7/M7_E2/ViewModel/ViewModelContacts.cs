using System.ComponentModel;
using Model;

namespace ViewModel
{
    public class ViewModelContacts : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int _indiceCourant;
        private ModelContacts _model;
        private Contact _nouveauContact;
        private string _fichierActif;

        private Contact ContactCourant
        {
            set;
            get;
        }

        public string Nom
        {
            get => ContactCourant.Nom;
            set => ContactCourant.Nom = value;
        }

        public string Prenom
        {
            get => ContactCourant.Prenom;
            set => ContactCourant.Prenom = value;
        }

        public int? NumeroCivique
        {
            get => ContactCourant.NumeroCivique;
            set => ContactCourant.NumeroCivique = value;
        }

        public string Rue
        {
            get => ContactCourant.Rue;
            set => ContactCourant.Rue = value;
        }

        public bool PrecedentExiste => _indiceCourant > 0;
        public bool ProchainExiste => _indiceCourant < _model.LesContacts.Count - 1;
        public bool PeutSauvegarder => _model.LesContacts.Count > 0 && _fichierActif != string.Empty;
        public bool PeutSauvegarderSous => _model.LesContacts.Count > 0;
        public bool PeutAnnuler => _nouveauContact == ContactCourant;

        public ViewModelContacts()
        {
            _model = new ModelContacts();
            _indiceCourant = 0;
            _fichierActif = string.Empty;
        }

        public void ChargerContacts(string pathFichier)
        {
            _fichierActif = pathFichier;
            _model.ChargerContacts(pathFichier);
            if (_model.LesContacts.Count > 0)
            {
                ContactCourant = _model.LesContacts[_indiceCourant];
            }
            _indiceCourant = 0;
        }

        public bool PeutAllerAuProchain()
        {
            return ProchainExiste && ContactCourant != _nouveauContact;
        }

        public bool PeutAllerAuPrecedent()
        {
            return PrecedentExiste && ContactCourant != _nouveauContact;
        }

        public void AllerAuProchain()
        {
            if (ProchainExiste)
            {
                _indiceCourant++;
                ContactCourant = _model.LesContacts[_indiceCourant];
                OnPropertyChanged();
            }
        }

        public void AllerAuPrecedent()
        {
            if (PrecedentExiste)
            {
                _indiceCourant--;
                ContactCourant = _model.LesContacts[_indiceCourant];
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SauvegarderSousContacts(string pathFichier)
        {
            _fichierActif = pathFichier;
            _model.SauvegarderContacts(pathFichier);
        }

        public void SauvegarderContacts()
        {
            if (_fichierActif != string.Empty)
            {
                _model.SauvegarderContacts(_fichierActif);
            }
        }

        public void NouveauContact()
        {
            _nouveauContact = new Contact();
            ContactCourant = _nouveauContact;
            OnPropertyChanged();
        }

        public void NouveauContactEnConstruction()
        {
            ContactCourant = _model.LesContacts[_indiceCourant];
            OnPropertyChanged();
        }
    }
}