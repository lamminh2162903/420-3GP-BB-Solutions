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

namespace Exercice1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _viewModel;

        public MainWindow()
        {
            _viewModel = new ViewModel();
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void Precedent_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AllerAuPrecedent();
        }

        private void Prochain_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AllerAuSuivant();
        }

        private void Retirer_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RetirerActuel();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (VerifierChamp())
            {
                _viewModel.AjouterContact(Nom.Text, Prenom.Text, NoCivique.Text, Rue.Text);
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
            _viewModel.CreerNouveauContact();
        }


        private void ChangerPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? resultat = dialog.ShowDialog();
            if (resultat.HasValue && resultat.Value)
            {
                string path = dialog.FileName;
                _viewModel.PathPhotoContact = path;
            }
        }
    }
}
