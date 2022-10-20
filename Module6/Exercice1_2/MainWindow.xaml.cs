using System;
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

namespace DepartExercices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Personne> lesPersonnes;
        int indiceActuel = -1;
        public MainWindow()
        {
            InitializeComponent();
            lesPersonnes = new List<Personne>();
            DataContext = null;
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
            // DataContext = null;
            // indiceActuel = -1;

            Nom.Text = "";
            Prenom.Text = "";
            NoCivique.Text = "";
            NoClient.Text = null;
            Rue.Text = "";
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
                DataContext = null;
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
        }

        private void ChangerPhoto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

