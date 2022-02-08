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
        public static RoutedCommand cmdAjouter = new RoutedCommand();
        public static RoutedCommand cmdRetirer = new RoutedCommand();
        public static RoutedCommand cmdNouveau = new RoutedCommand();
        public static RoutedCommand cmdPhoto = new RoutedCommand();
        public static RoutedCommand cmdProchain = new RoutedCommand();
        public static RoutedCommand cmdPrecedent = new RoutedCommand();


        private ViewModel _viewModel;

        public MainWindow()
        {
            _viewModel = new ViewModel();
            InitializeComponent();
            DataContext = _viewModel;
            ChoixTri.SelectedItem = _viewModel.ChoixTri;
        }
    


        private void Ajouter_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _viewModel.EstNouveauContact() && VerifierChamp();
        }

        private bool VerifierChamp()
        {
            bool reponse = !Nom.Text.Equals("");
            reponse = reponse ? !Prenom.Text.Equals("") : reponse;
            reponse = reponse ? !NoCivique.Text.Equals("") : reponse;
            reponse = reponse ? !Rue.Text.Equals("") : reponse;
            return reponse;
        }

        private void Ajouter_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (VerifierChamp())
            {
                _viewModel.AjouterContact();
            }
            else
            {
                MessageBox.Show("Il manque des informations");
            }
        }

        private void Retirer_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _viewModel.ContactEstDansListe();
        }

        private void Retirer_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _viewModel.RetirerActuel();
        }

        private void Nouveau_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Nouveau_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _viewModel.CreerNouveauContact();
        }

        private void ChangerPhoto_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ChangerPhoto_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? resultat = dialog.ShowDialog();
            if (resultat.HasValue && resultat.Value)
            {
                string path = dialog.FileName;
                _viewModel.PathPhotoContact = path;
            }
        }

        private void Precedent_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _viewModel.PrecedentPossible();
        }

        private void Precedent_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _viewModel.AllerAuPrecedent();
        }

        private void Prochain_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _viewModel.ProchainPossible();
        }

        private void Prochain_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _viewModel.AllerAuSuivant();
        }

        private void ChoixTri_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string choix = (string) ChoixTri.SelectedItem;
            _viewModel.ChoixTri = choix;
        }
    }
}
