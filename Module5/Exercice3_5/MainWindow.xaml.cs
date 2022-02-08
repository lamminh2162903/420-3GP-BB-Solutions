using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

using System.Xml;
using System.IO;

namespace Exercice3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Personne> lesPersonnes;

        Personne clientVide;
        int indiceActuel = -1;

        private string fichierXML = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/sauvegarde.xml";

        private XmlDocument document;

        public MainWindow()
        {
            InitializeComponent();
            lesPersonnes = new List<Personne>();
            clientVide = new Personne("", "", "", ""); 
            DataContext = clientVide;

            if (File.Exists(fichierXML))
            {
                document = new XmlDocument();   
                document.Load(fichierXML);
                ChargerXML();

            }


        }

        private void Precedent_Click(object sender, RoutedEventArgs e)
        {
            if (indiceActuel > 0)
            {
                indiceActuel = indiceActuel - 1;
                DataContext = lesPersonnes[indiceActuel];
            }
        }

        private void Prochain_Click(object sender, RoutedEventArgs e)
        {
            if (indiceActuel < lesPersonnes.Count - 1)
            {
                indiceActuel = indiceActuel + 1;
                DataContext = lesPersonnes[indiceActuel];
            }

        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {

            if (VerifierChamp())
            {
                Personne unePersonne = new Personne();
                unePersonne.Nom = Nom.Text;
                unePersonne.Prenom = Prenom.Text;
                unePersonne.NoCivique = NoCivique.Text;
                unePersonne.Rue = Rue.Text;
                lesPersonnes.Add(unePersonne);
                indiceActuel = lesPersonnes.Count - 1;
                DataContext = lesPersonnes[indiceActuel];
            }
            else
            {
                MessageBox.Show("Il manque des informations");
            }

            SauvegarderXML();
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            if (VerifierChamp() && indiceActuel > -1 && indiceActuel < lesPersonnes.Count)
            {
                Personne unePersonne = lesPersonnes[indiceActuel];
                unePersonne.Nom = Nom.Text;
                unePersonne.Prenom = Prenom.Text;
                unePersonne.NoCivique = NoCivique.Text;
                unePersonne.Rue = Rue.Text;
                DataContext = lesPersonnes[indiceActuel];
            }
            else
            {
                MessageBox.Show("Il manque des informations");
            }

            SauvegarderXML();
        }

        private bool VerifierChamp()
        {
            bool reponse = !Nom.Text.Equals("");
            reponse = reponse ? !Prenom.Text.Equals("") : reponse;
            reponse = reponse ? !NoCivique.Text.Equals("") : reponse;
            reponse = reponse ? !Rue.Text.Equals("") : reponse;
            return reponse;
        }

        private void Vider_Click(object sender, RoutedEventArgs e)
        {
           DataContext = clientVide;
        }

        private void Retirer_Click(object sender, RoutedEventArgs e)
        {
            if (indiceActuel < lesPersonnes.Count && indiceActuel != -1)
            {
                lesPersonnes.RemoveAt(indiceActuel);
            }

            if (lesPersonnes.Count == 0)
            {
                indiceActuel = -1;
                DataContext = clientVide;
            }
            else if (indiceActuel < lesPersonnes.Count)
            {
                DataContext = lesPersonnes[indiceActuel];
            }
            else
            {
                indiceActuel = lesPersonnes.Count - 1;
                DataContext = lesPersonnes[indiceActuel];
            }
            SauvegarderXML();
        }

        private void ChangerPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            bool? resultat = dialog.ShowDialog();

            if (resultat.HasValue && resultat.Value)
            {
                string path = dialog.FileName;
                if (lesPersonnes.Count > 0 && indiceActuel < lesPersonnes.Count)
                {
                    lesPersonnes[indiceActuel].PathPhoto = path;
                    DataContext = lesPersonnes[indiceActuel];
                }
            }
            SauvegarderXML();
        }


        private void ChargerXML()
        {
            lesPersonnes.Clear();

            XmlElement root = document.DocumentElement;
            IEnumerator enumeration = root.GetEnumerator();
            while (enumeration.MoveNext())
            {
                object obj = enumeration.Current;
                if (obj is XmlElement)
                {
                    XmlElement element = enumeration.Current as XmlElement;
                    lesPersonnes.Add(new Personne(element));
                }
            }

            if (lesPersonnes.Count > 0)
            {
                indiceActuel = 0;
                DataContext = lesPersonnes[indiceActuel];
            }
        }

        private void SauvegarderXML()
        {
            document = new XmlDocument();
            XmlElement root = document.CreateElement("Personnes");
            document.AppendChild(root);
            foreach (Personne unePersonne in lesPersonnes)
            {
                root.AppendChild(unePersonne.ToXML(document));
            }
            document.Save(fichierXML);
        }
    }
}
