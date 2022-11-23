using Model;

namespace ViewModel
{
    public class ViewModelContacts
    {
        private int _indiceCourant;
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

        private ModelContacts _model;
        public ViewModelContacts()
        {
            _model = new ModelContacts();
        }

        public void ChargerContacts(string pathFichier)
        {
            _model.ChargerContacts(pathFichier);
        }


    }
}