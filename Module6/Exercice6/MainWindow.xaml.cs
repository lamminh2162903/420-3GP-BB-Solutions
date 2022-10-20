using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml;

namespace Exercice4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Equipe> lesEquipes;

        public MainWindow()
        {
            InitializeComponent();
            lesEquipes = new ObservableCollection<Equipe>();

            ChargerFichierXml();

            ComboBoxEquipes.ItemsSource = lesEquipes;
        }

        private void ChargerFichierXml()
        {
            XmlDocument document = new XmlDocument();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/equipes.xml";
            document.Load(path);
            XmlElement racine = document.DocumentElement;


            XmlElement unNoeud = racine.GetElementsByTagName("Equipes")[0] as XmlElement;
            XmlNodeList lesEquipesXML = unNoeud.GetElementsByTagName("Equipe");

            foreach (XmlElement unElement in lesEquipesXML)
            {
                lesEquipes.Add(new Equipe(unElement));
            }

        }

        private void ComboBoxEquipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Equipe equipe = ComboBoxEquipes.SelectedItem as Equipe;
            ListBoxJoueurs.ItemsSource = equipe.Joueurs;
        }

        private void AjouterJoueur_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxEquipes.SelectedItem != null)
            {
                Equipe equipe = ComboBoxEquipes.SelectedItem as Equipe;
                string nom = InputNouveauJoueur.Text;
                equipe.AjouterJoueur(nom);
                SauvegarderXML();
            }           
        }
        private void RetirerJoueur_Click(object sender, RoutedEventArgs e)
        {
            Equipe equipe = ComboBoxEquipes.SelectedItem as Equipe;
            string nomJoueur = ListBoxJoueurs.SelectedItem as string;
            equipe.RetirerJoueur(nomJoueur);
            SauvegarderXML();
        }
        private void SauvegarderXML()
        {
            XmlDocument document = new XmlDocument();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/equipes.xml";
            XmlElement racine = document.CreateElement("Ligue");
            document.AppendChild(racine);

            XmlElement elementEquipe = document.CreateElement("Equipes");
            racine.AppendChild(elementEquipe);

            foreach (Equipe uneEquipe in lesEquipes)
            {
                XmlElement element= uneEquipe.ToXML(document);
                elementEquipe.AppendChild(element);
            }
            document.Save(path);
        }


    }
}
