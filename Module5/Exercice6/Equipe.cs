using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Exercice4
{
    class Equipe
    {

        public ObservableCollection<string> Joueurs
        {
            set;
            get;
        }

        public string Nom
        {
            set;
            get;
        }



        public Equipe(XmlElement element)
        {
            Nom = element.GetAttribute("nom");
            Joueurs = new ObservableCollection<string>();
            LireJoueurs(element);

        }


        public override string ToString()
        {
            return Nom;
        }

        private void LireJoueurs(XmlElement element)
        {
            XmlNodeList lesJoueurs = element.GetElementsByTagName("Joueur");
            foreach (XmlElement elementJoueur in lesJoueurs)
            {
                Joueurs.Add(elementJoueur.InnerText);
            }
        }

        public void AjouterJoueur(string nom)
        {
            Joueurs.Add(nom);
        }

        public void RetirerJoueur(string nom)
        {
            Joueurs.Remove(nom);
        }

        internal XmlElement ToXML(XmlDocument document)
        {
            XmlElement elementEquipe = document.CreateElement("Equipe");
            foreach (string nomJoueur in Joueurs)
            {
                XmlElement nouveauJoueur = document.CreateElement("Joueur");
                nouveauJoueur.InnerText = nomJoueur;
                elementEquipe.AppendChild(nouveauJoueur);
            }
            return elementEquipe;
        }
    }
}
