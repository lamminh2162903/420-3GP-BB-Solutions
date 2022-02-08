using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartExercices
{
    class Personne
    {
        private int _numero;

        private static int prochainNumero = 1;
        public string NoClient
        {
            get
            {
                return _numero.ToString();
            }
        }
        public string Nom
        {
            get;
            set;
        }
        public string Prenom
        {
            get;
            set;
        }
        public string NoCivique
        {
            set;
            get;
        }
        public string Rue
        {
            get;
            set;
        }
        public string PathPhoto
        {
            set;
            get;
        }

        public Personne()
        {
            _numero = prochainNumero++;
            PathPhoto = "NoImage.png";
        }

        public Personne(string nom, string prenom, string no, string rue) : this()
        {
            Nom = nom;
            Prenom = prenom;
            NoCivique = no;
            Rue = rue;
        }
    }
}
